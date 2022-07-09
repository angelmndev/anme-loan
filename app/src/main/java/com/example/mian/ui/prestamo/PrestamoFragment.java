package com.example.mian.ui.prestamo;

import android.app.Activity;
import android.app.DatePickerDialog;
import android.content.Context;
import android.os.Bundle;

import androidx.cardview.widget.CardView;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentActivity;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.Toast;

import com.example.mian.R;
import com.example.mian.interfaces.MyFragment;
import com.example.mian.libreria.AngLib;
import com.example.mian.ui.cliente.ClienteNuevoFragment;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link PrestamoFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class PrestamoFragment extends Fragment {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;

    public PrestamoFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment PrestamoFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static PrestamoFragment newInstance(String param1, String param2) {
        PrestamoFragment fragment = new PrestamoFragment();
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


    CardView cvNuevoPrestamo,cvRegistroPrestamo,cvModificarPrestamo,cvCancelarPrestamo;
    Fragment fragNuevoPrestamo,fragRegistroPrestamo,fragmentModificarPrestamo,fragmentCancelarPrestamo;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_prestamo, container, false);

        cvNuevoPrestamo = view.findViewById(R.id.cvNuevoPrestamo);
        cvRegistroPrestamo = view.findViewById(R.id.cvRegistroPrestamo);
        cvModificarPrestamo = view.findViewById(R.id.cvModificarPrestamo);
        cvCancelarPrestamo = view.findViewById(R.id.cvCancelarPrestamo);

        cvNuevoPrestamo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                fragNuevoPrestamo = new PrestamoNuevoFragment();
               /* FragmentTransaction transaction = getFragmentManager().beginTransaction();
                transaction.replace(R.id.prestamo_fragment, fragNuevoPrestamo);
                transaction.addToBackStack(null);
                transaction.commit();*/

                FragmentManager fragmentManager = getFragmentManager();
                FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
                fragmentTransaction.replace(R.id.prestamo_fragment, fragNuevoPrestamo).addToBackStack(null);
                fragmentTransaction.commit();
                fragmentTransaction.addToBackStack(null);

               // AngLib.showFragment(getContext(),R.id.prestamo_fragment,fragNuevoPrestamo);
            }
        });

        cvRegistroPrestamo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                fragRegistroPrestamo = new PrestamoRegistroFragment();
                AngLib.showFragment(getContext(),R.id.prestamo_fragment,fragRegistroPrestamo);
            }
        });

        cvModificarPrestamo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                fragmentModificarPrestamo = new PrestamoModificarFragment();
                AngLib.showFragment(getContext(),R.id.prestamo_fragment,fragmentModificarPrestamo);
            }
        });

        cvCancelarPrestamo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                fragmentCancelarPrestamo = new PrestamoCancelarFragment();
                AngLib.showFragment(getContext(),R.id.prestamo_fragment,fragmentCancelarPrestamo);
            }
        });

        return view;
    }
}