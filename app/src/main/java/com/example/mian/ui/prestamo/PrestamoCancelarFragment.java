package com.example.mian.ui.prestamo;

import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.Context;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.text.Editable;
import android.text.TextWatcher;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.example.mian.R;
import com.example.mian.adaptador.prestamo.PrestamoCancelarAdapter;
import com.example.mian.interfaces.ICliente;
import com.example.mian.interfaces.IPrestamo;
import com.example.mian.interfaces.IPrestamoHistorial;
import com.example.mian.libreria.AngLib;
import com.example.mian.modelo.Prestamo;
import com.example.mian.modelo.PrestamoHistorial;
import com.example.mian.ui.dialogo.Dialogo;
import com.example.mian.utilidades.Utilidades;
import com.firebase.ui.database.FirebaseRecyclerOptions;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.android.material.floatingactionbutton.FloatingActionButton;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;


public class PrestamoCancelarFragment extends Fragment implements IPrestamo {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;

    public PrestamoCancelarFragment() {
        // Required empty public constructor
    }

    public static PrestamoCancelarFragment newInstance(String param1, String param2) {
        PrestamoCancelarFragment fragment = new PrestamoCancelarFragment();
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
    //::::: A N G E L :::: C O D E :::: W R I T T E N ::::::
    private EditText etBuscarCliente;
    private TextView tvNombreCliente;
    private RecyclerView rvRegistroPrestamoCancelar;
    private FirebaseDatabase mDatabase;
    private DatabaseReference mReference;
    private ProgressDialog mDialog, mProgress;
    private PrestamoCancelarAdapter prestamoCancelarAdapter;
    private FloatingActionButton fabEliminar;
    private String idPrestamo;
    private String preClieDni;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.fragment_prestamo_cancelar, container, false);
        etBuscarCliente = view.findViewById(R.id.etBuscarCliente);
        tvNombreCliente = view.findViewById(R.id.tvNombreCliente);
        rvRegistroPrestamoCancelar = view.findViewById(R.id.rvRegistroPrestamoCancelar);
        fabEliminar = view.findViewById(R.id.fabEliminar);
        rvRegistroPrestamoCancelar.setLayoutManager(new LinearLayoutManager(getContext()));
        ShowAdapterPrestamoCancelar();

        etBuscarCliente.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }

            @Override
            public void afterTextChanged(Editable s) {
                if (etBuscarCliente.length() == 8) {
                    ObtenerDatosCliente(new ICliente() {
                        @Override
                        public void BuscarID(String IDCLIENTE) {

                        }

                        @Override
                        public void GenerarID(String IDCLIENTE) {

                        }

                        @Override
                        public void ObtenerDatos(String IDCLIENTE, String DNI, String NOMBRE, String APELLIDO, String SEXO) {
                            tvNombreCliente.setText(NOMBRE+" "+APELLIDO);
                            ShowRecordsPrestamoSearch(DNI);
                        }
                    },etBuscarCliente.getText().toString());
                    //ObtenerNombreCLiente(etBuscarCliente.getText().toString());
                }
            }
        });

        fabEliminar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(idPrestamo != null && preClieDni != null){
                    showDialog(getContext(),"MIAN","Estas seguro que quiere eliminar el prestamo seleccionado.?");
                }else{
                    Dialogo.showDialog(Dialogo.EstadoDialogo.error,getContext(),"MIAN","Por favor seleccione un registro");
                }

            }
        });

        return view;
    }

    //::: Controles de cuadro de dialogo
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
                UpdatePrestamoHistorial();
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

    //Metodo que permite adaptar a recycler view
    private void ShowAdapterPrestamoCancelar() {
        mDialog = AngLib.ShowProgressDialog(mProgress, getContext());
        FirebaseRecyclerOptions<Prestamo> options = new FirebaseRecyclerOptions.Builder<Prestamo>()
                .setQuery(FirebaseDatabase.getInstance().getReference().child(Utilidades.REF_PRESTAMO).orderByChild(Utilidades.PRE_ESTADO).startAt("1").endAt("1" + "\uf8ff"), Prestamo.class)
                .build();


        RecyclerPrestamoAdapter(options, mDialog);
    }

    //::::: METODO QUE PERMITE BUSCAR CLIENTE POR DNI
    private void ShowRecordsPrestamoSearch(String clieDni) {

        mDialog = AngLib.ShowProgressDialog(mProgress, getContext());
        FirebaseRecyclerOptions<Prestamo> options = new FirebaseRecyclerOptions.Builder<Prestamo>()
                .setQuery(FirebaseDatabase.getInstance().getReference().child(Utilidades.REF_PRESTAMO).orderByChild(Utilidades.PRE_ESTADO_CANTIDAD).startAt(clieDni+"(1)").endAt(clieDni+"(1)"+"\uf8ff"), Prestamo.class)
                .build();
        RecyclerPrestamoAdapter(options,mDialog);

    }


    // OBTENIENDO DATOS DEL CLIENTE
    private void ObtenerDatosCliente(ICliente iCliente, String clieDni){
        mDatabase = FirebaseDatabase.getInstance();
        mReference = mDatabase.getReference(Utilidades.REF_CLIENTE);
        mReference.orderByChild(Utilidades.CLIE_DNI).equalTo(clieDni).addValueEventListener(new ValueEventListener() {
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

    //::::: METODO QUE PERMITE ADAPTAR REGISTROS SIN CONDICION A RECYCLERVIEW
    private void RecyclerPrestamoAdapter(FirebaseRecyclerOptions<Prestamo> options, ProgressDialog dialog) {
        prestamoCancelarAdapter = new PrestamoCancelarAdapter(options, getContext(), dialog,this);
        prestamoCancelarAdapter.startListening();
        rvRegistroPrestamoCancelar.setAdapter(prestamoCancelarAdapter);
    }

    @Override
    public void onStart() {
        super.onStart();
        prestamoCancelarAdapter.startListening();
    }

    @Override
    public void onStop() {
        super.onStop();
        prestamoCancelarAdapter.stopListening();
    }


    @Override
    public void IDPrestamo(String IDPRESTAMO) {

    }

    @Override
    public void GetDatosPrestamo(String IDPH, String PRECLIEDNI) {

        if(IDPH != null && PRECLIEDNI != null){
            this.idPrestamo = IDPH;
            this.preClieDni = PRECLIEDNI;
            Toast.makeText(getContext(),IDPH+" "+PRECLIEDNI,Toast.LENGTH_SHORT).show();
        }else{
            this.idPrestamo = null;
            this.preClieDni = null;
        }
    }

    //Obtener IDPRESTAMOHISTORIAL
    private void GetIDPrestamo(IPrestamoHistorial iPrestamoHistorial){
        mDatabase = FirebaseDatabase.getInstance();
        mReference = mDatabase.getReference(Utilidades.REF_PRESTAMO);
        mReference.child(idPrestamo).addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                if(snapshot.exists()){
                    iPrestamoHistorial.ObtenerIDPH(snapshot.child(Utilidades.ID_PRESTAMO_HISTORIAL).getValue(String.class));
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });
    }

    //Modificar Prestamo Historial
    private void UpdatePrestamoHistorial(){
        mDialog = AngLib.ShowProgressDialog(mProgress,getContext());
        GetIDPrestamo(new IPrestamoHistorial() {
            @Override
            public void ObtenerDatos(PrestamoHistorial prestamoHistorial) {

            }

            @Override
            public void ObtenerIDPH(String idPH) {
                mDatabase = FirebaseDatabase.getInstance();
                mReference = mDatabase.getReference(Utilidades.REF_PRESTAMO_HISTORIAL);
                mReference.child(idPH).child(Utilidades.PH_COMENTARIO).setValue("Prestamo Eliminado en la fecha: "+ AngLib.obtenerFechaActual("Ica-Peru")).addOnSuccessListener(new OnSuccessListener<Void>() {
                    @Override
                    public void onSuccess(Void aVoid) {
                        DeleteLoan();
                    }
                });
            }
        });

    }

    //Eliminar prestamo de forma logica
    private void DeleteLoan(){
        mDatabase = FirebaseDatabase.getInstance();
        mReference = mDatabase.getReference(Utilidades.REF_PRESTAMO);
        mReference.child(idPrestamo).removeValue().addOnSuccessListener(new OnSuccessListener<Void>() {
            @Override
            public void onSuccess(Void aVoid) {
                mDialog.dismiss();
                Dialogo.showDialog(Dialogo.EstadoDialogo.succes,getContext(),"MIAN","Prestamo eliminado exitosamente.");
            }
        });

    }
}