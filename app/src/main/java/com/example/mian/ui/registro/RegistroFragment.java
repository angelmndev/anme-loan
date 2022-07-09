
package com.example.mian.ui.registro;

import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.mian.ConexionSQLiteHelper;
import com.example.mian.R;
import com.example.mian.adaptador.prestamo.PrestamoItem;
import com.example.mian.modelo.PrestamoItemModel;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Locale;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link RegistroFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class RegistroFragment extends Fragment {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;

    public RegistroFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment RegistroFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static RegistroFragment newInstance(String param1, String param2) {
        RegistroFragment fragment = new RegistroFragment();
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

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.fragment_registro, container, false);



        return view;
    }

    //Metodo que permite obtenr fecha LOG
    public static Date ParseFecha(String fecha) {
        SimpleDateFormat formato = new SimpleDateFormat("dd/MM/yyyy", Locale.ENGLISH);
        Date fechaDate = null;
        try {
            fechaDate = formato.parse(fecha);
        } catch (ParseException ex) {
            System.out.println(ex);
        }
        return fechaDate;
    }

    private List<PrestamoItem> buildItemList() {

        List<PrestamoItem> itemList = new ArrayList<>();
        ConexionSQLiteHelper con = new ConexionSQLiteHelper(getContext(), "dbmian", null, 1);
        SQLiteDatabase database = con.getReadableDatabase();
        Cursor cursor = database.rawQuery("select  clieNombre,idCliente from prestamo inner join prestamoHistorial on idPrestamoHistorialFK = idPrestamoHistorial inner join cliente on idClienteFK = idCliente group by idCliente ", null);
        if (cursor.getCount() > 0) {
            while (cursor.moveToNext()) {
               // PrestamoItem item = new PrestamoItem(cursor.getString(0), buildSubItemList(cursor.getInt(1)));
                //itemList.add(item);
            }
        }
        cursor.close();
        return itemList;
    }

    private List<PrestamoItemModel> buildSubItemList(int _idCliente) {
        List<PrestamoItemModel> subItemList = new ArrayList<>();

        ConexionSQLiteHelper con = new ConexionSQLiteHelper(getContext(), "dbmian", null, 1);
        SQLiteDatabase database = con.getReadableDatabase();
        Cursor cursor = database.rawQuery("select idCliente,idPrestamoHistorial,idPrestamo,clieDni,clieNombre,clieApellido,preHisImporteCredito,preHisModalidadPago," +
                "preHisTipoPago,preHisNumeroCuota,preHisTasaInteres,preHisImporteCuota,preHisTotalPagar, preHisFecha from prestamo " +
                "inner join prestamoHistorial on idPrestamoHistorialFK = idPrestamoHistorial " +
                "inner join cliente on idClienteFK = idCliente where idClienteFK = '" + _idCliente + "'", null);
        if (cursor.getCount() > 0) {
            while (cursor.moveToNext()) {
                int idCliente = cursor.getInt(0);
                int idPrestamoHistorial = cursor.getInt(1);
                int idPrestamo = cursor.getInt(2);
                String clieDni = cursor.getString(3);
                String clieNombre = cursor.getString(4);
                String clieApellido = cursor.getString(5);
                double presImporteCredito = cursor.getDouble(6);
                String presModalidad = cursor.getString(7);
                String presTipoPago = cursor.getString(8);
                int presNumeroCUota = cursor.getInt(9);
                double presTasaInteres = cursor.getDouble(10);
                double presImporteCuota = cursor.getDouble(11);
                double presTotal = cursor.getDouble(12);
                String presFecha = DateFormat.getDateInstance(DateFormat.FULL).format(ParseFecha(cursor.getString(13)));

                PrestamoItemModel subItem = new PrestamoItemModel(idCliente,idPrestamoHistorial,idPrestamo,clieDni,clieNombre,clieApellido,presImporteCredito,presModalidad,presTipoPago,presNumeroCUota,presTasaInteres,presImporteCuota,presTotal,presFecha);
                subItemList.add(subItem);
            }
        }
        cursor.close();
        return subItemList;
    }
}