package com.example.mian.ui.cliente;

import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.os.strictmode.SqliteObjectLeakedViolation;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.example.mian.ConexionSQLiteHelper;
import com.example.mian.R;
import com.example.mian.utilidades.Utilidades;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link ClienteDetalleFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class ClienteDetalleFragment extends Fragment {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;

    public ClienteDetalleFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment ClienteDetalleFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static ClienteDetalleFragment newInstance(String param1, String param2) {
        ClienteDetalleFragment fragment = new ClienteDetalleFragment();
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

    //::::::::::Angel code written :::::::::::::
    ConexionSQLiteHelper con;
    TextView tvNombreCliente, tvDireccionCliente, tvCodigoCliente, tvDniCliente, tvTelefonoCliente, tvSexoMasculino, tvImporteCredito, tvGanancia, tvSaldoTotal;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_cliente_detalle, container, false);

        tvNombreCliente = view.findViewById(R.id.tvNombreCliente);
        tvDireccionCliente = view.findViewById(R.id.tvDireccionCliente);
        tvCodigoCliente = view.findViewById(R.id.tvCodigoCliente);
        tvDniCliente = view.findViewById(R.id.tvDniCliente);
        tvTelefonoCliente = view.findViewById(R.id.tvTelefonoCliente);
        tvSexoMasculino = view.findViewById(R.id.tvSexoMasculino);
        tvImporteCredito = view.findViewById(R.id.tvImporteCredito);
        tvGanancia = view.findViewById(R.id.tvGanancia);
        tvSaldoTotal = view.findViewById(R.id.tvSaldoTotal);

        int idCliente = (getArguments() != null) ? getArguments().getInt(Utilidades.ID_CLIENTE) : 0;
        ShowUserDetail(idCliente);
        ShowDeatailPrestamo(idCliente);
        return view;
    }

    private void ShowUserDetail(int idCliente) {
        con = new ConexionSQLiteHelper(getContext(), Utilidades.DBNAME, null, 1);
        SQLiteDatabase database = con.getReadableDatabase();
        Cursor cursor = database.rawQuery("SELECT * FROM cliente WHERE idCliente = '" + idCliente + "'", null);
        if (cursor.getCount() > 0) {
            while (cursor.moveToNext()) {
                String nombreCliente = cursor.getString(2) + " " + cursor.getString(3);
                String direccionCliente = cursor.getString(7);
                String codigoCliente = cursor.getString(1);
                String dniCliente = cursor.getString(5);
                String telefonoCliente = cursor.getString(6);
                String sexoCliente = cursor.getString(8);

                tvNombreCliente.setText(nombreCliente);
                tvDireccionCliente.setText(direccionCliente);
                tvCodigoCliente.setText(codigoCliente);
                tvDniCliente.setText(dniCliente);
                tvTelefonoCliente.setText(telefonoCliente);
                tvSexoMasculino.setText(sexoCliente);
            }
        }

        cursor.close();
    }

    //Metodo que permite obtener los datos y ganacias del cliente
    private void ShowDeatailPrestamo(int idCliente){
        con = new ConexionSQLiteHelper(getContext(), Utilidades.DBNAME, null, 1);
        SQLiteDatabase database = con.getReadableDatabase();
        String query = "SELECT sum(preHisImporteCredito) as preHisImporteCredito,(sum(preHisImporteCredito)*preHisTasaInteres/100) AS ganancia, (sum(preHisImporteCredito)+(sum(preHisImporteCredito)*preHisTasaInteres/100)) as total FROM prestamoHistorial inner join cliente on idClienteFK = idCliente where idCliente = '"+idCliente+"'";
        Cursor cursor = database.rawQuery(query,null);
        if(cursor.getCount()>0){
            while (cursor.moveToNext()){
                tvImporteCredito.setText(cursor.getString(0));
                tvGanancia.setText(cursor.getString(1));
                tvSaldoTotal.setText(cursor.getString(2));
            }
        }
        cursor.close();
    }



}