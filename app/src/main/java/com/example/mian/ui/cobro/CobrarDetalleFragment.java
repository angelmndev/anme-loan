package com.example.mian.ui.cobro;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.AutoCompleteTextView;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.TextView;

import com.example.mian.R;
import com.example.mian.modelo.Cliente;
import com.example.mian.modelo.PrestamoHistorial;
import com.example.mian.utilidades.Utilidades;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.util.ArrayList;
import java.util.List;

import de.hdodenhof.circleimageview.CircleImageView;

public class CobrarDetalleFragment extends Fragment {

    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;

    public CobrarDetalleFragment() {
        // Required empty public constructor
    }


    public static CobrarDetalleFragment newInstance(String param1, String param2) {
        CobrarDetalleFragment fragment = new CobrarDetalleFragment();
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
    //:::::::: A N G E L ::::: W R I T T E N ::::: C O D E :::::::
    private FirebaseDatabase mDatabase;
    private DatabaseReference mReference;
    private CircleImageView ivFoto;
    private Spinner spNumeroCuota;
    private AutoCompleteTextView acNumeroCuota;
    private TextView tvNombreCliente,tvDniCliente, tvImporteCredito, tvModalidadPago, tvTipoPago, tvNumeroCuota, tvTasaInteres, tvImporteCuota, tvTotalPagar, tvFechaPrestamo;
    private Button btRegresar,btCobrar;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_cobrar_detalle, container, false);

        ivFoto = view.findViewById(R.id.ivFotoCliente);
        tvNombreCliente = view.findViewById(R.id.tvNombreCliente);
        tvDniCliente = view.findViewById(R.id.tvClieDni);
        tvImporteCredito = view.findViewById(R.id.tvImporteCredito);
        tvModalidadPago = view.findViewById(R.id.tvModalidadPago);
        tvTipoPago = view.findViewById(R.id.tvTipoPago);
        tvNumeroCuota = view.findViewById(R.id.tvNumeroCuota);
        tvTasaInteres = view.findViewById(R.id.tvTasaInteres);
        tvImporteCuota = view.findViewById(R.id.tvImporteCuota);
        tvTotalPagar = view.findViewById(R.id.tvTotalPagar);
        tvFechaPrestamo = view.findViewById(R.id.tvFechaPrestamo);
        acNumeroCuota = view.findViewById(R.id.acNumeroCuota);
        btRegresar = view.findViewById(R.id.btRegresar);
        btCobrar = view.findViewById(R.id.btCobrar);

        String idPrestamo = getArguments().getString(Utilidades.ID_PRESTAMO);
        String idPrestamoHistorial = getArguments().getString(Utilidades.ID_PRESTAMO_HISTORIAL);
        String preClieDni = getArguments().getString(Utilidades.PRE_CLIE_DNI);

        ObtenerDatosCliente(preClieDni);
        ObtenerDatosPH(idPrestamoHistorial);

        return view;
    }

    //Obtener datos de prestamo historial por ID
    private void ObtenerDatosPH(String IDPH){

        mDatabase = FirebaseDatabase.getInstance();
        mReference = mDatabase.getReference(Utilidades.REF_PRESTAMO_HISTORIAL);
        mReference.child(IDPH).addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                PrestamoHistorial ph = snapshot.getValue(PrestamoHistorial.class);
                tvImporteCredito.setText(String.valueOf(ph.getPhImporteCredito()));
                tvModalidadPago.setText(ph.getPhModalidadPago());
                tvTipoPago.setText(ph.getPhTipoPago());
                tvNumeroCuota.setText(String.valueOf(ph.getPhNumeroCuota()));
                tvTasaInteres.setText(String.valueOf(ph.getPhTasaInteres()));
                tvImporteCuota.setText(String.valueOf(ph.getPhImporteCuota()));
                tvTotalPagar.setText(String.valueOf(ph.getPhTotalPagar()));
                tvFechaPrestamo.setText(ph.getPhFecha());

                LLenarComboNumeroCuota(ph.getPhNumeroCuota());
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });
    }

    //Obtener datos cliente segun DNI
    private void ObtenerDatosCliente(String clieDni){
        mDatabase = FirebaseDatabase.getInstance();
        mReference = mDatabase.getReference(Utilidades.REF_CLIENTE);
        mReference.orderByChild(Utilidades.CLIE_DNI).equalTo(clieDni).addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                for(DataSnapshot ds: snapshot.getChildren()){
                    Cliente cliente = ds.getValue(Cliente.class);
                    tvNombreCliente.setText(cliente.getClieNombre()+" "+cliente.getClieApellido());
                    tvDniCliente.setText(cliente.getClieDni());
                    if(cliente.getClieSexo().equals("Masculino")){
                        ivFoto.setImageResource(R.drawable.ic_hombre);
                    }else {
                        ivFoto.setImageResource(R.drawable.ic_mujer);
                    }
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });
    }


    private void LLenarComboNumeroCuota(int NCuota){

        List<String> listNCuota =  new ArrayList<>();
        for(int i = 1;i <= NCuota;i++){
            listNCuota.add(String.valueOf(i));
        }

        ArrayAdapter<String> adapter = new ArrayAdapter<>(getContext(), R.layout.list_item, listNCuota);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        acNumeroCuota.setAdapter(adapter);

    }

}