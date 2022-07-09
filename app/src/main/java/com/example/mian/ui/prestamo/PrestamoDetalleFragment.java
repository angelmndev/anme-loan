package com.example.mian.ui.prestamo;

import android.app.ProgressDialog;
import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.widget.Toast;

import com.example.mian.R;
import com.example.mian.adaptador.prestamo.PrestamoDetalleAdapter;
import com.example.mian.libreria.AngLib;
import com.example.mian.modelo.Prestamo;
import com.example.mian.utilidades.Utilidades;
import com.firebase.ui.database.FirebaseRecyclerOptions;
import com.google.firebase.database.FirebaseDatabase;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link PrestamoDetalleFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class PrestamoDetalleFragment extends Fragment{

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;

    public PrestamoDetalleFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment PrestamoDetalleFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static PrestamoDetalleFragment newInstance(String param1, String param2) {
        PrestamoDetalleFragment fragment = new PrestamoDetalleFragment();
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

    //Angel code
    private PrestamoDetalleAdapter mPrestamoDetalleAdapter;
    private RecyclerView rvPrestamoHistorial;
    private ProgressDialog mDialog,mProgress;
    private TextView tvNombreCliente;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_prestamo_detalle, container, false);

        rvPrestamoHistorial = view.findViewById(R.id.rvPrestamoDetalle);
        tvNombreCliente = view.findViewById(R.id.tvNombreCliente);

        rvPrestamoHistorial.setLayoutManager(new LinearLayoutManager(getContext()));

        String clieDni =(getArguments()!=null)?getArguments().getString(Utilidades.PG_CLIE_DNI):"";
        String clieNombre = (getArguments()!=null)?getArguments().getString(Utilidades.PG_CLIE_NOMBRE):"";

        Toast.makeText(getContext(),clieDni,Toast.LENGTH_SHORT).show();
        ShowPrestamoHistorial(clieDni);
        tvNombreCliente.setText(clieNombre);



        return view;
    }


    private void ShowPrestamoHistorial(String clieDni) {
        mDialog = AngLib.ShowProgressDialog(mProgress,getContext());
        FirebaseRecyclerOptions<Prestamo> options = new FirebaseRecyclerOptions.Builder<Prestamo>()
                    .setQuery(FirebaseDatabase.getInstance().getReference().child(Utilidades.REF_PRESTAMO).orderByChild(Utilidades.PRE_CLIE_DNI).startAt(clieDni).endAt(clieDni+"\uf8ff"), Prestamo.class)
                .build();
        RecyclerClienteAdapter(options,mDialog);
    }

    //::::: METODO QUE PERMITE ADAPTAR REGISTROS SIN CONDICION A RECYCLERVIEW
    private void RecyclerClienteAdapter(FirebaseRecyclerOptions<Prestamo> options, ProgressDialog dialog){
        mPrestamoDetalleAdapter = new PrestamoDetalleAdapter(options, getContext(),dialog);
        mPrestamoDetalleAdapter.startListening();
        rvPrestamoHistorial.setAdapter(mPrestamoDetalleAdapter);
    }

    @Override
    public void onStart() {
        super.onStart();
        mPrestamoDetalleAdapter.startListening();
    }

    @Override
    public void onStop() {
        super.onStop();
        mPrestamoDetalleAdapter.stopListening();
    }

    public static Date ParseFecha(String fecha)
    {
        SimpleDateFormat formato = new SimpleDateFormat("dd/MM/yyyy", Locale.ENGLISH);
        Date fechaDate = null;
        try {
            fechaDate = formato.parse(fecha);
        }
        catch (ParseException ex)
        {
            System.out.println(ex);
        }
        return fechaDate;
    }

}