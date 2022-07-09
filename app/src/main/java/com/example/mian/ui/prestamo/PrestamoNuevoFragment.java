package com.example.mian.ui.prestamo;

import android.app.AlertDialog;
import android.app.DatePickerDialog;

import android.app.ProgressDialog;
import android.content.Context;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;

import android.text.Editable;
import android.text.TextWatcher;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.ProgressBar;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.example.mian.R;
import com.example.mian.interfaces.ICliente;
import com.example.mian.interfaces.IGenerarID;
import com.example.mian.interfaces.IPrestamoGrouping;
import com.example.mian.libreria.AngLib;
import com.example.mian.libreria.AngTools;
import com.example.mian.modelo.Cliente;
import com.example.mian.modelo.Prestamo;
import com.example.mian.modelo.PrestamoGrouping;
import com.example.mian.modelo.PrestamoHistorial;
import com.example.mian.ui.dialogo.Dialogo;
import com.example.mian.utilidades.Utilidades;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.android.material.textfield.TextInputEditText;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.text.DecimalFormat;
import java.util.Calendar;

public class PrestamoNuevoFragment extends Fragment {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;

    public PrestamoNuevoFragment() {
        // Required empty public constructor
    }

    public static PrestamoNuevoFragment newInstance(String param1, String param2) {
        PrestamoNuevoFragment fragment = new PrestamoNuevoFragment();
        Bundle args = new Bundle();
        args.putString(ARG_PARAM1, param1);
        args.putString(ARG_PARAM2, param2);
        fragment.setArguments(args);
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            mParam1 = getArguments().getString(ARG_PARAM1);
            mParam2 = getArguments().getString(ARG_PARAM2);
        }
    }


    private Button btGuardarPrestamo, btRegresarPrestamo;
    private Spinner txtModalidad, txtPrestamoTipoPago;
    private ProgressBar mProgressBar;
    private TextInputEditText txtDni, txtNombre, txtImporteCredito, txtNumeroCuota, txtTasaInteres, txtImporteCuota, txtTotalPagar, txtFechaPrestamo;

    private ProgressDialog mDialog, progressDialog;
    //::::: FIREBASE
    private FirebaseDatabase mDatabase;
    private DatabaseReference mRefence;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.fragment_prestamo_nuevo, container, false);

        btGuardarPrestamo = view.findViewById(R.id.btGuardarPrestamo);
        btRegresarPrestamo = view.findViewById(R.id.btRegresarPrestamo);
        mProgressBar = view.findViewById(R.id.mProgressBar);
        txtDni = view.findViewById(R.id.txtPrestamoDni);
        txtNombre = view.findViewById(R.id.txtPrestamoCliente);
        txtImporteCredito = view.findViewById(R.id.txtPrestamoImporteCredito);
        txtModalidad = view.findViewById(R.id.txtPrestamoModalidad);
        txtNumeroCuota = view.findViewById(R.id.txtPrestamoNumeroCuota);
        txtTasaInteres = view.findViewById(R.id.txtPrestamoTasaInteres);
        txtImporteCuota = view.findViewById(R.id.txtPrestamoImporteCuota);
        txtTotalPagar = view.findViewById(R.id.txtPrestamoTotalPagar);
        txtFechaPrestamo = view.findViewById(R.id.txtPrestamoFecha);
        txtPrestamoTipoPago = view.findViewById(R.id.txtPrestamoTipoPago);

        txtDni.setEnabled(true);
        txtNombre.setEnabled(true);
        mProgressBar.setVisibility(View.GONE);

        //::::: MUESTRA UNA VENTANA DE TIPO DIALOGO DATAPICKER
        txtFechaPrestamo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Calendar mcurrentDate = Calendar.getInstance();

                int mDay = mcurrentDate.get(Calendar.DAY_OF_MONTH);
                int mMonth = mcurrentDate.get(Calendar.MONTH);
                int mYear = mcurrentDate.get(Calendar.YEAR);
                DatePickerDialog datePickerDialog = new DatePickerDialog(getContext(), new DatePickerDialog.OnDateSetListener() {
                    @Override
                    public void onDateSet(DatePicker view, int year, int month, int dayOfMonth) {
                        month = month + 1;
                        String date = dayOfMonth + "/" + month + "/" + year;
                        txtFechaPrestamo.setText(date);
                    }
                }, mYear, mMonth, mDay);
                datePickerDialog.show();
            }
        });


        //::::: METODO QUE PERMITE OBTENER NOMBRE Y ID DEL CLIENTE
        txtDni.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }

            @Override
            public void afterTextChanged(Editable s) {

                String dni = txtDni.getText().toString();
                mRefence = FirebaseDatabase.getInstance().getReference();
                if (txtDni.getText().toString().length() == 8) {
                    mDialog = AngLib.ShowProgressDialog(progressDialog, getContext());
                }

                mRefence.child("Cliente").orderByChild("clieDni").equalTo(dni).addValueEventListener(new ValueEventListener() {
                    @Override
                    public void onDataChange(@NonNull DataSnapshot snapshot) {

                        for (DataSnapshot ds : snapshot.getChildren()) {
                            Cliente cliente = ds.getValue(Cliente.class);
                            String clieNombreApellido = cliente.getClieNombre() + " " + cliente.getClieApellido();

                            if (!clieNombreApellido.equals("")) {
                                txtNombre.setText(clieNombreApellido);
                                mDialog.dismiss();
                            }
                        }

                    }

                    @Override
                    public void onCancelled(@NonNull DatabaseError error) {

                    }
                });

            }
        });

        txtImporteCredito.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }

            @Override
            public void afterTextChanged(Editable s) {

                if (txtPrestamoTipoPago.getSelectedItem().toString().equals("Interes capital")) {
                    if (!txtImporteCredito.getText().toString().equals("") && !txtTasaInteres.getText().toString().equals("") && !txtNumeroCuota.getText().toString().equals("")) {
                        DecimalFormat decimalFormat = new DecimalFormat("###.##");
                        txtImporteCuota.setText(String.valueOf(decimalFormat.format(ImporteCuotaPrestamo(TipoPago.interesCapital))));
                        txtTotalPagar.setText(decimalFormat.format(TotalPagar()));
                    }
                } else if (txtPrestamoTipoPago.getSelectedItem().toString().equals("Solo interes")) {
                    if (!txtImporteCredito.getText().toString().equals("") && !txtTasaInteres.getText().toString().equals("")) {
                        DecimalFormat decimalFormat = new DecimalFormat("###.##");
                        txtImporteCuota.setText(String.valueOf(decimalFormat.format(ImporteCuotaPrestamo(TipoPago.soloInteres))));
                    }
                }

            }
        });

        txtNumeroCuota.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }

            @Override
            public void afterTextChanged(Editable s) {
                if (txtPrestamoTipoPago.getSelectedItem().toString().equals("Interes capital")) {
                    if (!txtImporteCredito.getText().toString().equals("") && !txtTasaInteres.getText().toString().equals("") && !txtNumeroCuota.getText().toString().equals("")) {
                        DecimalFormat decimalFormat = new DecimalFormat("###.##");
                        txtImporteCuota.setText(String.valueOf(decimalFormat.format(ImporteCuotaPrestamo(TipoPago.interesCapital))));
                        txtTotalPagar.setText(decimalFormat.format(TotalPagar()));
                    }
                } else if (txtPrestamoTipoPago.getSelectedItem().toString().equals("Solo interes")) {
                    if (!txtImporteCredito.getText().toString().equals("") && !txtTasaInteres.getText().toString().equals("")) {
                        DecimalFormat decimalFormat = new DecimalFormat("###.##");
                        txtImporteCuota.setText(String.valueOf(decimalFormat.format(ImporteCuotaPrestamo(TipoPago.soloInteres))));
                    }
                }
            }
        });

        txtTasaInteres.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }

            @Override
            public void afterTextChanged(Editable s) {
                if (txtPrestamoTipoPago.getSelectedItem().toString().equals("Interes capital")) {
                    if (!txtImporteCredito.getText().toString().equals("") && !txtTasaInteres.getText().toString().equals("") && !txtNumeroCuota.getText().toString().equals("")) {
                        DecimalFormat decimalFormat = new DecimalFormat("###.##");
                        txtImporteCuota.setText(String.valueOf(decimalFormat.format(ImporteCuotaPrestamo(TipoPago.interesCapital))));
                        txtTotalPagar.setText(decimalFormat.format(TotalPagar()));
                    }
                } else if (txtPrestamoTipoPago.getSelectedItem().toString().equals("Solo interes")) {
                    if (!txtImporteCredito.getText().toString().equals("") && !txtTasaInteres.getText().toString().equals("")) {
                        DecimalFormat decimalFormat = new DecimalFormat("###.##");
                        txtImporteCuota.setText(String.valueOf(decimalFormat.format(ImporteCuotaPrestamo(TipoPago.soloInteres))));
                    }
                }
            }
        });


        //::::: SPINNER TIPO DE PAGO
        txtPrestamoTipoPago.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                String tipoPago = txtPrestamoTipoPago.getSelectedItem().toString();

                switch (tipoPago) {
                    case "Tipo de pago":
                        txtNumeroCuota.setEnabled(false);
                        break;
                    case "Solo interes":
                        txtNumeroCuota.setEnabled(false);
                        break;
                    case "Interes capital":
                        txtNumeroCuota.setEnabled(true);
                        break;
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        //::::: GUARDAR PRESTAMO :)
        btGuardarPrestamo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
               /* if (ValidarCampoVacioET()) {
                    mDialog = AngLib.ShowProgressDialog(progressDialog, getContext());
                    GuardarPrestamoHistorial();
                } else {
                    Dialogo.showDialog(Dialogo.EstadoDialogo.error, getContext(), "MIAN", "Por favor no deje campos vacios");
                }*/
                GuardarPrestamoHistorial();
            }
        });

        btRegresarPrestamo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //NavController navController = Navigation.findNavController(v);
                //navController.navigate(R.id.navigation_prestamo);
               /* ObtenerIDPrestamo(new IPrestamo() {
                    @Override
                    public void IDPrestamo(String idPrestamo) {
                        Toast.makeText(getContext(),idPrestamo,Toast.LENGTH_SHORT).show();
                    }
                });*/

                /*ObtenerID(new IPrestamoHistorial() {
                    @Override
                    public void IDPrestamoHistorial(String idPrestamo) {
                        Toast.makeText(getContext(),idPrestamo,Toast.LENGTH_SHORT).show();
                    }
                });*/
                ActualizarPrestamoGrouping();

            }
        });

        return view;
    }


    @Override
    public void onStart() {
        super.onStart();
    }

    private enum TipoPago {
        interesCapital,
        soloInteres
    }

    //metodo que permite obtener el importe de cuota
    private double ImporteCuotaPrestamo(TipoPago tipoPago) {

        double importeCredito;
        double tasaInteres;
        int numeroCuota;
        double importeCuota = 0;
        switch (tipoPago) {
            case interesCapital:
                importeCredito = Double.parseDouble(txtImporteCredito.getText().toString());
                tasaInteres = Double.parseDouble(txtTasaInteres.getText().toString());
                numeroCuota = Integer.parseInt(txtNumeroCuota.getText().toString());
                importeCuota = ((importeCredito * tasaInteres / 100) + importeCredito) / numeroCuota;
                break;
            case soloInteres:
                importeCredito = Double.parseDouble(txtImporteCredito.getText().toString());
                tasaInteres = Double.parseDouble(txtTasaInteres.getText().toString());


                importeCuota = (importeCredito * tasaInteres / 100);
                break;
        }
        return importeCuota;
    }

    //::::: METODO QUE PERMITE OBTENER EL PAGO TOTAL
    private double TotalPagar() {
        double importeCredito = Double.parseDouble(txtImporteCredito.getText().toString());
        double tasaInteres = Double.parseDouble(txtTasaInteres.getText().toString());

        double interesTotal = (importeCredito * tasaInteres / 100);

        return importeCredito + interesTotal;

    }


    private void GuardarPrestamoHistorial() {
        mDialog = AngLib.ShowProgressDialog(progressDialog,getContext());
        AngTools tools = new AngTools();
        tools.GenerarID(new IGenerarID() {
            @Override
            public void GenerarID(String ID) {

                ObtenerIDCliente(new ICliente() {
                    @Override
                    public void BuscarID(String IDCLIENTE) {

                        String idPrestamoHistorial = ID;
                        String idCliente = IDCLIENTE;
                        String idUser = tools.IDCurrentUser();
                        double importeCredito = Double.parseDouble(txtImporteCredito.getText().toString());
                        double importeCuota = Double.parseDouble(txtImporteCuota.getText().toString());
                        String modalidadPago = txtModalidad.getSelectedItem().toString();
                        int numeroCuota = Integer.parseInt(txtNumeroCuota.getText().toString());
                        double tasaInteres = Double.parseDouble(txtTasaInteres.getText().toString());
                        String tipoPago = txtPrestamoTipoPago.getSelectedItem().toString();
                        double totalPagar = Double.parseDouble(txtTotalPagar.getText().toString());
                        String fecha = txtFechaPrestamo.getText().toString();
                        String comentario = "Nuevo prestamo agregado en: "+ fecha;

                        PrestamoHistorial prestamoHistorial = new PrestamoHistorial(idPrestamoHistorial,idCliente,idUser,importeCredito,importeCuota,modalidadPago,numeroCuota,tasaInteres,
                                tipoPago,totalPagar,fecha,comentario);
                        mDatabase = FirebaseDatabase.getInstance();
                        mRefence = mDatabase.getReference(Utilidades.REF_PRESTAMO_HISTORIAL);
                        mRefence.child(idPrestamoHistorial).setValue(prestamoHistorial).addOnSuccessListener(new OnSuccessListener<Void>() {
                            @Override
                            public void onSuccess(Void aVoid) {
                                GuardarPrestamo(ID);
                            }
                        });
                    }

                    @Override
                    public void GenerarID(String IDCLIENTE) {

                    }

                    @Override
                    public void ObtenerDatos(String IDCLIENTE, String DNI, String NOMBRE, String APELLIDO, String SEXO) {

                    }

                });
            }
        }, Utilidades.REF_PRESTAMO_HISTORIAL, Utilidades.PREF_PRESTAMO_HISTORIAL);
    }


    //AGRENADO PRESTAMO
    private void GuardarPrestamo(String idPrestamoHistorial){
        String idPH = idPrestamoHistorial;
        AngTools tools = new AngTools();
        tools.GenerarID(new IGenerarID() {
            @Override
            public void GenerarID(String ID) {
                String idPrestamo = ID;
                String dni = txtDni.getText().toString();
                String idPrestamoHistorial = idPH ;
                String tipoPrestamo = txtPrestamoTipoPago.getSelectedItem().toString();
                double importeCredito = Double.parseDouble(txtImporteCredito.getText().toString());
                String estado = "1";
                String estadoCantidad = dni+"(1)";
                String fecha = txtFechaPrestamo.getText().toString();

                Prestamo prestamoNew = new Prestamo(idPrestamo,dni,idPrestamoHistorial,tipoPrestamo,importeCredito,estado,estadoCantidad,fecha);
                mDatabase = FirebaseDatabase.getInstance();
                mRefence = mDatabase.getReference(Utilidades.REF_PRESTAMO);
                mRefence.child(idPrestamo).setValue(prestamoNew).addOnSuccessListener(new OnSuccessListener<Void>() {
                    @Override
                    public void onSuccess(Void aVoid) {
                        GuardarPrestamoGrouping();
                    }
                });
            }
        },Utilidades.REF_PRESTAMO,Utilidades.PREF_PRESTAMO);
    }

    // AGREGANDO PRESTAMO GROUP
    private void GuardarPrestamoGrouping(){

        ValidarClienteExistente(new IPrestamoGrouping() {
            @Override
            public void GroupImporteCredito(double importeCredito) {

            }

            @Override
            public void GroupClienteExistente(boolean estado) {

                if(!estado){
                    NuevoPrestamoGrouping();
                }else{
                    ActualizarPrestamoGrouping();
                }

            }

            @Override
            public void GroupBuscarIDPGDni(String IDPG) {

            }
        });
    }

    //MODIFICA EL PRESTAMO GROUPING
    private void ActualizarPrestamoGrouping(){
        BuscarIDPGDni(new IPrestamoGrouping() {
            @Override
            public void GroupImporteCredito(double importeCredito) {

            }

            @Override
            public void GroupClienteExistente(boolean estado) {

            }

            @Override
            public void GroupBuscarIDPGDni(String IDPG) {

                ObtenerDatosCliente(new ICliente() {
                    @Override
                    public void BuscarID(String IDCLIENTE) {

                    }

                    @Override
                    public void GenerarID(String IDCLIENTE) {

                    }

                    @Override
                    public void ObtenerDatos(String IDCLIENTE, String DNI, String NOMBRE, String APELLIDO, String SEXO) {

                        ObtenerSumaTotalImporteCredito(new IPrestamoGrouping() {
                            @Override
                            public void GroupImporteCredito(double importeCredito) {
                                String idPrestamoGrouping = IDPG;
                                String idCliente = IDCLIENTE;
                                String pgClieDni = DNI;
                                String pgClieNombre = NOMBRE;
                                String pgClieApellido = APELLIDO;
                                String pgClieSexo = SEXO;
                                double pgImporteCredito = importeCredito;
                                String pgFecha = txtFechaPrestamo.getText().toString();
                                String pgEstado = "1";
                                PrestamoGrouping prestamoGrouping = new PrestamoGrouping(idPrestamoGrouping,idCliente,pgClieDni,pgClieNombre,pgClieApellido,pgClieSexo,pgImporteCredito,pgFecha,pgEstado);
                                mDatabase = FirebaseDatabase.getInstance();
                                mRefence = mDatabase.getReference(Utilidades.REF_PRESTAMO_GROUPING);
                                mRefence.child(idPrestamoGrouping).setValue(prestamoGrouping).addOnSuccessListener(new OnSuccessListener<Void>() {
                                    @Override
                                    public void onSuccess(Void aVoid) {
                                       // Toast.makeText(getContext(),"PRESTAMO GROUPING ACTUALIZADO",Toast.LENGTH_SHORT).show();
                                        mDialog.dismiss();
                                        Dialogo.showDialog(Dialogo.EstadoDialogo.succes,getContext(),"MIAN","Prestamo nuevo agregado exitosamente..:)");
                                    }
                                });
                            }

                            @Override
                            public void GroupClienteExistente(boolean estado) {

                            }

                            @Override
                            public void GroupBuscarIDPGDni(String IDPG) {

                            }
                        });
                    }
                });
            }
        });
    }

    //OBTENER EL ID DEL PRESTAMO GROUPING SEGUN DNI
    private void BuscarIDPGDni(IPrestamoGrouping iPrestamoGrouping){
        mDatabase = FirebaseDatabase.getInstance();
        mRefence = mDatabase.getReference(Utilidades.REF_PRESTAMO_GROUPING);
        mRefence.orderByChild(Utilidades.PG_CLIE_DNI).equalTo(txtDni.getText().toString()).addListenerForSingleValueEvent(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                String idPrestamoGrouping = null;

                for(DataSnapshot ds: snapshot.getChildren()){
                    idPrestamoGrouping = ds.getKey();
                }
                iPrestamoGrouping.GroupBuscarIDPGDni(idPrestamoGrouping);
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });
    }
    //AGREGAR UN NUEVO PRESTAMO GROUPING
    private void NuevoPrestamoGrouping(){
        AngTools tools = new AngTools();
        tools.GenerarID(new IGenerarID() {
            @Override
            public void GenerarID(String IDENTITY) {
                ObtenerDatosCliente(new ICliente() {
                    @Override
                    public void BuscarID(String IDCLIENTE) {

                    }

                    @Override
                    public void GenerarID(String IDCLIENTE) {

                    }

                    @Override
                    public void ObtenerDatos(String IDCLIENTE, String DNI, String NOMBRE, String APELLIDO, String SEXO) {

                        ObtenerSumaTotalImporteCredito(new IPrestamoGrouping() {
                            @Override
                            public void GroupImporteCredito(double importeCredito) {
                                String idPrestamoGrouping = IDENTITY;
                                String idCliente = IDCLIENTE;
                                String pgClieDni = DNI;
                                String pgClieNombre = NOMBRE;
                                String pgClieApellido = APELLIDO;
                                String pgClieSexo = SEXO;
                                double pgImporteCredito = importeCredito;
                                String pgFecha = txtFechaPrestamo.getText().toString();
                                String pgEstado = "1";


                                PrestamoGrouping prestamoGrouping = new PrestamoGrouping(idPrestamoGrouping,idCliente,pgClieDni,pgClieNombre,pgClieApellido,pgClieSexo,pgImporteCredito,pgFecha,pgEstado);

                                mDatabase = FirebaseDatabase.getInstance();
                                mRefence = mDatabase.getReference(Utilidades.REF_PRESTAMO_GROUPING);
                                mRefence.child(idPrestamoGrouping).setValue(prestamoGrouping).addOnSuccessListener(new OnSuccessListener<Void>() {
                                    @Override
                                    public void onSuccess(Void aVoid) {
                                        mDialog.dismiss();
                                        Dialogo.showDialog(Dialogo.EstadoDialogo.succes,getContext(),"MIAN","Prestamo nuevo agregado exitosamente..:)");
                                    }
                                });
                            }

                            @Override
                            public void GroupClienteExistente(boolean estado) {

                            }

                            @Override
                            public void GroupBuscarIDPGDni(String IDPG) {

                            }
                        });

                    }
                });
            }
        },Utilidades.REF_PRESTAMO_GROUPING,Utilidades.PREF_PRESTAMO_GROUPING);
    }

    // SUMAR LOS IMPORTES DE CREDITO DE CADA CLIENTE
    private void ObtenerSumaTotalImporteCredito(IPrestamoGrouping iPrestamoGrouping){
        mDatabase = FirebaseDatabase.getInstance();
        mRefence = mDatabase.getReference(Utilidades.REF_PRESTAMO);
        mRefence.orderByChild(Utilidades.PRE_CLIE_DNI).equalTo(txtDni.getText().toString()).addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                double importeCredito = 0;
                for(DataSnapshot ds: snapshot.getChildren()){
                    importeCredito += Double.parseDouble(ds.child("preImporteCredito").getValue().toString());
                }
                iPrestamoGrouping.GroupImporteCredito(importeCredito);
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });
    }

    // BUSCA EL ID DEL CLIENTE POR MEDIO DE SU DNI
    private void ObtenerIDCliente(ICliente iCliente) {
        mDatabase = FirebaseDatabase.getInstance();
        mRefence = mDatabase.getReference(Utilidades.REF_CLIENTE);
        mRefence.orderByChild(Utilidades.CLIE_DNI).equalTo(txtDni.getText().toString()).addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                String idCliente = null;

                for (DataSnapshot ds : snapshot.getChildren()) {
                    idCliente = ds.getKey();
                }

                iCliente.BuscarID(idCliente);

            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });
    }

    // OBTENIENDO DATOS DEL CLIENTE
    private void ObtenerDatosCliente(ICliente iCliente){
        mDatabase = FirebaseDatabase.getInstance();
        mRefence = mDatabase.getReference(Utilidades.REF_CLIENTE);
        mRefence.orderByChild(Utilidades.CLIE_DNI).equalTo(txtDni.getText().toString()).addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                String IDCLIENTE = null;
                String DNI = null;
                String NOMBRE = null;
                String APELLIDO = null;
                String SEXO = null;
                for (DataSnapshot ds : snapshot.getChildren()) {
                    IDCLIENTE = ds.child(Utilidades.ID_CLIENTE).getValue().toString();
                    DNI = ds.child(Utilidades.CLIE_DNI).getValue().toString();
                    NOMBRE = ds.child(Utilidades.CLIE_NOMBRE).getValue().toString();
                    APELLIDO = ds.child(Utilidades.CLIE_APELLIDO).getValue().toString();
                    SEXO = ds.child(Utilidades.CLIE_SEXO).getValue().toString();
                }
                iCliente.ObtenerDatos(IDCLIENTE,DNI,NOMBRE,APELLIDO,SEXO);
            }
            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });
    }

    private void ValidarClienteExistente(IPrestamoGrouping iPrestamoGrouping) {

        mRefence = FirebaseDatabase.getInstance().getReference(Utilidades.REF_PRESTAMO_GROUPING);
        mRefence.orderByChild(Utilidades.PG_CLIE_DNI).equalTo(txtDni.getText().toString()).addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                long cantChildren = snapshot.getChildrenCount();

                if(cantChildren>0){
                    PrestamoGrouping prestamoGrouping = null;
                    for (DataSnapshot ds : snapshot.getChildren()) {
                        prestamoGrouping = ds.getValue(PrestamoGrouping.class);
                    }

                    if(!prestamoGrouping.getPgClieDni().equals(txtDni.getText().toString())){
                        iPrestamoGrouping.GroupClienteExistente(false);
                    }else{
                        iPrestamoGrouping.GroupClienteExistente(true);
                    }
                }else{
                    iPrestamoGrouping.GroupClienteExistente(false);
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });
    }

    //::::: SHOW PROGRESSBAR
    private void ShowProgressBar(int estado) {
        switch (estado) {
            case 1:
                mProgressBar.setVisibility(View.VISIBLE);
                break;
            case 0:
                mProgressBar.setVisibility(View.GONE);
                break;
        }

    }

    //VALIDAR CAMPO VACIO
    private boolean ValidarCampoVacioET() {
        TextInputEditText[] texts = {txtDni, txtNombre, txtImporteCredito, txtNumeroCuota, txtTasaInteres, txtImporteCuota, txtTotalPagar, txtFechaPrestamo};
        boolean isEmpty = false;

        for (TextInputEditText text : texts) {

            if (text.getText().toString().equals("")) {
                text.setError("Todos los campos son importanes");
                isEmpty = false;
            } else {
                isEmpty = true;
            }
        }

        return isEmpty;
    }

    private ImageView ivEstado;
    private TextView tvTitulo, tvMensaje;
    private Button btAceptar, btCancelar;
    private ImageButton btCerrar;

    public void showDialog(Context context, String titulo, String mensaje) {
        AlertDialog.Builder builder = new AlertDialog.Builder(context);
        LayoutInflater inflater = LayoutInflater.from(context);

        View view = inflater.inflate(R.layout.dialogo_confirmation, null);
        ivEstado = view.findViewById(R.id.ivEstado);
        tvTitulo = view.findViewById(R.id.tvTitulo);
        tvMensaje = view.findViewById(R.id.tvMensaje);
        btAceptar = view.findViewById(R.id.btAceptar);
        btCancelar = view.findViewById(R.id.btCancelar);
        btCerrar = view.findViewById(R.id.btCerrar);

        tvTitulo.setText(titulo);
        tvMensaje.setText(mensaje);
        builder.setView(view);

        final AlertDialog dialog = builder.create();
        dialog.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));

        btAceptar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                LimpiarCampos();
                dialog.dismiss();
            }
        });

        btCancelar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                dialog.dismiss();
            }
        });

        btCerrar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                dialog.dismiss();
            }
        });

        dialog.show();
    }


    //::::: METODO QUE PERMITE LIMPIAR CAMPOS
    private void LimpiarCampos() {
        txtDni.setText("");
        txtNombre.setText("");
        txtImporteCredito.setText("");
        txtModalidad.setSelection(0);
        txtNumeroCuota.setText("");
        txtTasaInteres.setText("");
        txtImporteCuota.setText("");
        txtTotalPagar.setText("");
        txtFechaPrestamo.setText("");
        txtPrestamoTipoPago.setSelection(0);
        txtDni.setFocusable(true);
        txtDni.requestFocus();
    }


}