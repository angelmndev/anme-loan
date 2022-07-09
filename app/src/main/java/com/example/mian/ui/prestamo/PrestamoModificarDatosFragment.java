package com.example.mian.ui.prestamo;

import android.app.DatePickerDialog;
import android.app.ProgressDialog;
import android.content.ContentValues;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Build;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.RequiresApi;
import androidx.fragment.app.Fragment;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;

import android.text.Editable;
import android.text.TextWatcher;
import android.view.Display;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.Spinner;
import android.widget.Toast;

import com.example.mian.ConexionSQLiteHelper;
import com.example.mian.R;
import com.example.mian.interfaces.ICliente;
import com.example.mian.interfaces.IGenerarID;
import com.example.mian.interfaces.IPrestamo;
import com.example.mian.interfaces.IPrestamoGrouping;
import com.example.mian.interfaces.IPrestamoHistorial;
import com.example.mian.libreria.AngLib;
import com.example.mian.libreria.AngTools;
import com.example.mian.modelo.Prestamo;
import com.example.mian.modelo.PrestamoGroup;
import com.example.mian.modelo.PrestamoGrouping;
import com.example.mian.modelo.PrestamoHistorial;
import com.example.mian.ui.dialogo.Dialogo;
import com.example.mian.utilidades.Utilidades;
import com.google.android.gms.tasks.OnFailureListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.android.material.textfield.TextInputEditText;
import com.google.android.material.textfield.TextInputLayout;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link PrestamoModificarDatosFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class PrestamoModificarDatosFragment extends Fragment {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;

    public PrestamoModificarDatosFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment PrestamoModificarDatosFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static PrestamoModificarDatosFragment newInstance(String param1, String param2) {
        PrestamoModificarDatosFragment fragment = new PrestamoModificarDatosFragment();
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

            String idPrestamoHistorial = (getArguments() != null) ? getArguments().getString(Utilidades.ID_PRESTAMO_HISTORIAL) : "";
            String clieDni = (getArguments() != null) ? getArguments().getString(Utilidades.PRE_CLIE_DNI) : "";
            this.idPrestamo = (getArguments() != null) ? getArguments().getString(Utilidades.ID_PRESTAMO) : "";

            DatosPrestamo(new IPrestamoHistorial() {
                @Override
                public void ObtenerDatos(PrestamoHistorial prestamoHistorial) {
                    txtImporteCredito.setText(String.valueOf(prestamoHistorial.getPhImporteCredito()));
                    txtModalidad.setSelection(getIndexModalidad(txtModalidad, prestamoHistorial.getPhModalidadPago()));
                    txtPrestamoTipoPago.setSelection(getIndexTipoPago(txtPrestamoTipoPago, prestamoHistorial.getPhTipoPago()));
                    txtNumeroCuota.setText(String.valueOf(prestamoHistorial.getPhNumeroCuota()));
                    txtTasaInteres.setText(String.valueOf(prestamoHistorial.getPhTasaInteres()));
                    txtImporteCuota.setText(String.valueOf(prestamoHistorial.getPhImporteCuota()));
                    txtTotalPagar.setText(String.valueOf(prestamoHistorial.getPhTotalPagar()));
                    txtFechaPrestamo.setText(prestamoHistorial.getPhFecha());
                }

                @Override
                public void ObtenerIDPH(String idPH) {

                }
            }, idPrestamoHistorial);

            ObtenerDatosCliente(new ICliente() {
                @Override
                public void BuscarID(String IDCLIENTE) {

                }

                @Override
                public void GenerarID(String IDCLIENTE) {

                }

                @Override
                public void ObtenerDatos(String IDCLIENTE, String DNI, String NOMBRE, String APELLIDO, String SEXO) {
                    txtDni.setText(DNI);
                    txtNombre.setText(NOMBRE + " " + APELLIDO);
                }
            }, clieDni);

        }
    }

    //:::::::: A N G E L ::::: W R I T T E N ::::: C O D E :::::::
    private String idPrestamo;
    private FirebaseDatabase mDatabase;
    private DatabaseReference mReference;
    private Button btGuardarPrestamo, btRegresarPrestamo;
    private Spinner txtModalidad, txtPrestamoTipoPago;
    private TextInputEditText txtDni, txtNombre, txtImporteCredito, txtNumeroCuota, txtTasaInteres, txtImporteCuota, txtTotalPagar, txtFechaPrestamo;

    private ProgressDialog mDialog, mProgress;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.fragment_prestamo_modificar_datos, container, false);
        btGuardarPrestamo = view.findViewById(R.id.btGuardarPrestamo);
        btRegresarPrestamo = view.findViewById(R.id.btRegresarPrestamo);

        txtDni = view.findViewById(R.id.txtPrestamoDni);
        txtNombre = view.findViewById(R.id.txtPrestamoCliente);
        txtImporteCredito = view.findViewById(R.id.txtPrestamoImporteCredito);
        txtModalidad = view.findViewById(R.id.txtPrestamoModalidad);
        txtPrestamoTipoPago = view.findViewById(R.id.txtPrestamoTipoPago);
        txtNumeroCuota = view.findViewById(R.id.txtPrestamoNumeroCuota);
        txtTasaInteres = view.findViewById(R.id.txtPrestamoTasaInteres);
        txtImporteCuota = view.findViewById(R.id.txtPrestamoImporteCuota);
        txtTotalPagar = view.findViewById(R.id.txtPrestamoTotalPagar);
        txtFechaPrestamo = view.findViewById(R.id.txtPrestamoFecha);

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

        //spinner tipo de pago
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

        //Guadar prestamo
        btGuardarPrestamo.setOnClickListener(new View.OnClickListener() {
            @RequiresApi(api = Build.VERSION_CODES.LOLLIPOP)
            @Override
            public void onClick(View v) {
                //GuardarPerstamo();
                //ModificarPrestamo();
                GuardarPrestamoHistorial();
                //ModificarPerstamo();
            }
        });

        btRegresarPrestamo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //NavController navController = Navigation.findNavController(v);
                //navController.navigate(R.id.navigation_prestamo);
                //Prueba();
                //GuardarPretamoGroup();
                // GuardarPrestamoHistorial();
                IPrestamo iPrestamo = new IPrestamo() {
                    @Override
                    public void IDPrestamo(String IDPRESTAMO) {
                        Toast.makeText(getContext(), IDPRESTAMO, Toast.LENGTH_SHORT).show();
                    }

                    @Override
                    public void GetDatosPrestamo(String IDPH, String PRECLIEDNI) {

                    }
                };
            }
        });

        return view;
    }


    //MODIFICAR PRESTAMO
    private void ActualizarPrestamo(String IDPH) {
        String idPrestamo = this.idPrestamo;
        String dni = txtDni.getText().toString();
        String idPrestamoHistorial = IDPH;
        String tipoPrestamo = txtPrestamoTipoPago.getSelectedItem().toString();
        double importeCredito = Double.parseDouble(txtImporteCredito.getText().toString());
        String estado = "1";
        String estadoCantidad = dni + "(1)";
        String fecha = txtFechaPrestamo.getText().toString();

        Prestamo prestamoNew = new Prestamo(idPrestamo, dni, idPrestamoHistorial, tipoPrestamo, importeCredito, estado, estadoCantidad, fecha);
        mDatabase = FirebaseDatabase.getInstance();
        mReference = mDatabase.getReference(Utilidades.REF_PRESTAMO);
        mReference.child(idPrestamo).setValue(prestamoNew).addOnSuccessListener(new OnSuccessListener<Void>() {
            @Override
            public void onSuccess(Void aVoid) {
                Toast.makeText(getContext(), "PRESTAMO GUARDADO", Toast.LENGTH_SHORT).show();
                GuardarPrestamoGrouping();
            }
        });


    }

    //INSERTAR PRESTAMO HISTORIAL
    private void GuardarPrestamoHistorial() {
        AngTools tools = new AngTools();
        tools.GenerarID(new IGenerarID() {
            @Override
            public void GenerarID(String ID) {

                ObtenerIDCliente(new ICliente() {
                    @Override
                    public void BuscarID(String IDCLIENTE) {

                        String IDPHANT = (getArguments() != null) ? getArguments().getString(Utilidades.ID_PRESTAMO_HISTORIAL) : "";
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
                        String comentario = "Modificado prestamo historial de: " + IDPHANT + " en la fecha" + fecha;

                        PrestamoHistorial prestamoHistorial = new PrestamoHistorial(idPrestamoHistorial, idCliente, idUser, importeCredito, importeCuota, modalidadPago, numeroCuota, tasaInteres,
                                tipoPago, totalPagar, fecha, comentario);
                        mDatabase = FirebaseDatabase.getInstance();
                        mReference = mDatabase.getReference(Utilidades.REF_PRESTAMO_HISTORIAL);
                        mReference.child(idPrestamoHistorial).setValue(prestamoHistorial).addOnSuccessListener(new OnSuccessListener<Void>() {
                            @Override
                            public void onSuccess(Void aVoid) {
                                ActualizarPrestamo(ID);
                                Toast.makeText(getContext(), "PRESTAMO HISTORIAL AGREGADO", Toast.LENGTH_SHORT).show();
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

    // AGREGANDO PRESTAMO GROUP
    private void GuardarPrestamoGrouping() {

        ValidarClienteExistente(new IPrestamoGrouping() {
            @Override
            public void GroupImporteCredito(double importeCredito) {

            }

            @Override
            public void GroupClienteExistente(boolean estado) {

                if (estado) {
                    ActualizarPrestamoGrouping();
                }

            }

            @Override
            public void GroupBuscarIDPGDni(String IDPG) {

            }
        });
    }

    //ACTUALIZAR PRESTAMOGROUPING
    private void ActualizarPrestamoGrouping() {
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
                                PrestamoGrouping prestamoGrouping = new PrestamoGrouping(idPrestamoGrouping, idCliente, pgClieDni, pgClieNombre, pgClieApellido, pgClieSexo, pgImporteCredito, pgFecha, pgEstado);
                                mDatabase = FirebaseDatabase.getInstance();
                                mReference = mDatabase.getReference(Utilidades.REF_PRESTAMO_GROUPING);
                                mReference.child(idPrestamoGrouping).setValue(prestamoGrouping).addOnSuccessListener(new OnSuccessListener<Void>() {
                                    @Override
                                    public void onSuccess(Void aVoid) {
                                        Toast.makeText(getContext(), "PRESTAMO GROUPING ACTUALIZADO", Toast.LENGTH_SHORT).show();
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
                }, txtDni.getText().toString());
            }
        });
    }

    //OBTENER EL ID DEL PRESTAMO GROUPING SEGUN DNI
    private void BuscarIDPGDni(IPrestamoGrouping iPrestamoGrouping) {
        mDatabase = FirebaseDatabase.getInstance();
        mReference = mDatabase.getReference(Utilidades.REF_PRESTAMO_GROUPING);
        mReference.orderByChild(Utilidades.PG_CLIE_DNI).equalTo(txtDni.getText().toString()).addListenerForSingleValueEvent(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                String idPrestamoGrouping = null;

                for (DataSnapshot ds : snapshot.getChildren()) {
                    idPrestamoGrouping = ds.getKey();
                }
                iPrestamoGrouping.GroupBuscarIDPGDni(idPrestamoGrouping);
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });
    }

    // SUMAR LOS IMPORTES DE CREDITO DE CADA CLIENTE
    private void ObtenerSumaTotalImporteCredito(IPrestamoGrouping iPrestamoGrouping) {
        mDatabase = FirebaseDatabase.getInstance();
        mReference = mDatabase.getReference(Utilidades.REF_PRESTAMO);
        mReference.orderByChild(Utilidades.PRE_CLIE_DNI).equalTo(txtDni.getText().toString()).addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                double importeCredito = 0;
                for (DataSnapshot ds : snapshot.getChildren()) {
                    importeCredito += Double.parseDouble(ds.child("preImporteCredito").getValue().toString());
                }
                iPrestamoGrouping.GroupImporteCredito(importeCredito);
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });
    }

    //VALIDAR SI EL CLIENTE YA EXISTE EN PRESTAMOGROUPING
    private void ValidarClienteExistente(IPrestamoGrouping iPrestamoGrouping) {

        mReference = FirebaseDatabase.getInstance().getReference(Utilidades.REF_PRESTAMO_GROUPING);
        mReference.orderByChild(Utilidades.PG_CLIE_DNI).equalTo(txtDni.getText().toString()).addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                long cantChildren = snapshot.getChildrenCount();

                if (cantChildren > 0) {
                    PrestamoGrouping prestamoGrouping = null;
                    for (DataSnapshot ds : snapshot.getChildren()) {
                        prestamoGrouping = ds.getValue(PrestamoGrouping.class);
                    }

                    if (!prestamoGrouping.getPgClieDni().equals(txtDni.getText().toString())) {
                        iPrestamoGrouping.GroupClienteExistente(false);
                    } else {
                        iPrestamoGrouping.GroupClienteExistente(true);
                    }
                } else {
                    iPrestamoGrouping.GroupClienteExistente(false);
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });
    }

    // BUSCA EL ID DEL CLIENTE POR MEDIO DE SU DNI
    private void ObtenerIDCliente(ICliente iCliente) {
        mDatabase = FirebaseDatabase.getInstance();
        mReference = mDatabase.getReference(Utilidades.REF_CLIENTE);
        mReference.orderByChild(Utilidades.CLIE_DNI).equalTo(txtDni.getText().toString()).addValueEventListener(new ValueEventListener() {
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

    //OBTENIENDO DATOS DE PRESTAMO
    private void DatosPrestamo(IPrestamoHistorial iPrestamoHistorial, String idPrestamoHistorial) {

        mDialog = AngLib.ShowProgressDialog(mProgress, getContext());


        mDatabase = FirebaseDatabase.getInstance();
        mReference = mDatabase.getReference(Utilidades.REF_PRESTAMO_HISTORIAL);
        mReference.child(idPrestamoHistorial).addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {

                PrestamoHistorial prestamoHistorial = snapshot.getValue(PrestamoHistorial.class);
                iPrestamoHistorial.ObtenerDatos(prestamoHistorial);
                mDialog.dismiss();
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });

    }


    //OBTENER DATOS DEL CLIENTE
    private void ObtenerDatosCliente(ICliente iCliente, String clieDni) {

        mDatabase = FirebaseDatabase.getInstance();
        mReference = mDatabase.getReference();
        mReference.child(Utilidades.REF_CLIENTE).orderByChild(Utilidades.CLIE_DNI).equalTo(clieDni).addValueEventListener(new ValueEventListener() {
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
                iCliente.ObtenerDatos(IDCLIENTE, DNI, NOMBRE, APELLIDO, SEXO);
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });

    }

    //Metodo que permite obtener el indice de spinner tipo de prestamo
    private int getIndexTipoPago(Spinner txtPrestamoTipoPago, String prestamoTipoPago) {
        for (int i = 0; i < txtPrestamoTipoPago.getCount(); i++) {
            if (txtPrestamoTipoPago.getItemAtPosition(i).toString().equalsIgnoreCase(prestamoTipoPago)) {
                return i;
            }
        }
        return 0;
    }

    //Metodo que permite obtener el indice de spinner modalidad
    private int getIndexModalidad(Spinner txtModalidad, String modalidad) {
        for (int i = 0; i < txtModalidad.getCount(); i++) {
            if (txtModalidad.getItemAtPosition(i).toString().equalsIgnoreCase(modalidad)) {
                return i;
            }
        }
        return 0;
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

    //metodo que permite obtener el pago total
    private double TotalPagar() {
        double importeCredito = Double.parseDouble(txtImporteCredito.getText().toString());
        double tasaInteres = Double.parseDouble(txtTasaInteres.getText().toString());

        double interesTotal = (importeCredito * tasaInteres / 100);

        return importeCredito + interesTotal;

    }


}