package com.example.mian.ui.prestamo;

import android.app.ProgressDialog;
import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.mian.R;
import com.example.mian.adaptador.prestamo.PrestamoRegistroAdapter;
import com.example.mian.libreria.AngLib;
import com.example.mian.modelo.PrestamoGroup;
import com.example.mian.modelo.PrestamoGrouping;
import com.example.mian.utilidades.Utilidades;
import com.firebase.ui.database.FirebaseRecyclerOptions;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;


/**
 * A simple {@link Fragment} subclass.
 * Use the {@link PrestamoRegistroFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class PrestamoRegistroFragment extends Fragment {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;

    public PrestamoRegistroFragment() {
        // Required empty public constructor61138817
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment PrestamoRegistroFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static PrestamoRegistroFragment newInstance(String param1, String param2) {
        PrestamoRegistroFragment fragment = new PrestamoRegistroFragment();
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

    //::::: ANGEL CODE
    RecyclerView rvRegistroPrestamo;

    private ProgressDialog mDialog,mProgress;

    private FirebaseDatabase mDatabase;
    private DatabaseReference mRefence;
    private PrestamoRegistroAdapter prestamoRegistroAdapter;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.fragment_prestamo_registro, container, false);

        rvRegistroPrestamo = view.findViewById(R.id.rvRegistroPrestamo);
        rvRegistroPrestamo.setLayoutManager(new LinearLayoutManager(getContext()));

        ShowPrestamo();

        return view;
    }


    private void ShowPrestamo() {

        mDialog = AngLib.ShowProgressDialog(mProgress,getContext());
        FirebaseRecyclerOptions<PrestamoGrouping> options = new FirebaseRecyclerOptions.Builder<PrestamoGrouping>()
                .setQuery(FirebaseDatabase.getInstance().getReference().child(Utilidades.REF_PRESTAMO_GROUPING), PrestamoGrouping.class)
                .build();

        RecyclerPrestamoAdapter(options,mDialog);
    }

    //::::: METODO QUE PERMITE ADAPTAR REGISTROS SIN CONDICION A RECYCLERVIEW
    private void RecyclerPrestamoAdapter(FirebaseRecyclerOptions<PrestamoGrouping> options, ProgressDialog dialog){
        prestamoRegistroAdapter = new PrestamoRegistroAdapter(options, getContext(),dialog);
        prestamoRegistroAdapter.startListening();
        rvRegistroPrestamo.setAdapter(prestamoRegistroAdapter);
    }

    @Override
    public void onStart() {
        super.onStart();
        prestamoRegistroAdapter.startListening();
    }

    @Override
    public void onStop() {
        super.onStop();
        prestamoRegistroAdapter.stopListening();
    }


    public static Date ParseFecha(String fecha)
    {
        SimpleDateFormat formato = new SimpleDateFormat("dd/MM/yyyy",Locale.ENGLISH);
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