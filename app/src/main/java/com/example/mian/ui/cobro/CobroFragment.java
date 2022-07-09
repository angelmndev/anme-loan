package com.example.mian.ui.cobro;

import android.app.ProgressDialog;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.cardview.widget.CardView;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.text.Editable;
import android.text.TextWatcher;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.TextView;

import com.example.mian.ConexionSQLiteHelper;
import com.example.mian.R;
import com.example.mian.adaptador.SubItem;
import com.example.mian.adaptador.cobro.CobranzaAdapter;
import com.example.mian.adaptador.prestamo.PrestamoModificarAdapter;
import com.example.mian.interfaces.ICliente;
import com.example.mian.libreria.AngLib;
import com.example.mian.modelo.Prestamo;
import com.example.mian.ui.prestamo.PrestamoNuevoFragment;
import com.example.mian.utilidades.Utilidades;
import com.firebase.ui.database.FirebaseRecyclerOptions;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Locale;

public class CobroFragment extends Fragment {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;

    public CobroFragment() {
        // Required empty public constructor
    }

    public static CobroFragment newInstance(String param1, String param2) {
        CobroFragment fragment = new CobroFragment();
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

    private CardView cvCobrar,cvModificarCobro,cvCancelarCobro,cvRegistroCobro;
    private Fragment fragCobrar,fragModificarCobro,fragCancelarCobro,fragRegistroCobro;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view =inflater.inflate(R.layout.fragment_cobro, container, false);

        cvCobrar = view.findViewById(R.id.cvCobrar);
        cvModificarCobro = view.findViewById(R.id.cvModificarCobro);
        cvCancelarCobro = view.findViewById(R.id.cvCancelarCobro);
        cvRegistroCobro = view.findViewById(R.id.cvRegistroCobro);

        cvCobrar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                fragCobrar = new CobrarFragment();
               /* FragmentTransaction transaction = getFragmentManager().beginTransaction();
                transaction.replace(R.id.prestamo_fragment, fragNuevoPrestamo);
                transaction.addToBackStack(null);
                transaction.commit();*/

                FragmentManager fragmentManager = getFragmentManager();
                FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
                fragmentTransaction.replace(R.id.cobro_fragment, fragCobrar).addToBackStack(null);
                fragmentTransaction.commit();
                fragmentTransaction.addToBackStack(null);

                // AngLib.showFragment(getContext(),R.id.prestamo_fragment,fragNuevoPrestamo);
            }
        });

        return view;
    }



}