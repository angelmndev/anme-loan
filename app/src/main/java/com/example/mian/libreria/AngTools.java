package com.example.mian.libreria;

import androidx.annotation.NonNull;

import com.example.mian.interfaces.IGenerarID;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.util.ArrayList;
import java.util.List;

public class AngTools {
    FirebaseDatabase mDatabase;
    DatabaseReference mRefence;
    public void  GenerarID(IGenerarID iGenerarID, String reference, String prefijo){
        mDatabase = FirebaseDatabase.getInstance();
        mRefence = mDatabase.getReference(reference);
        mRefence.addListenerForSingleValueEvent(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {

                List<Integer> listaID = new ArrayList<>();
                for (DataSnapshot ds : snapshot.getChildren()) {
                    String[] ID =  ds.getKey().split("-");
                    int id = Integer.parseInt(ID[1]);
                    listaID.add(id);
                }

                if(listaID.size()>0){
                    int IDMAYOR = listaID.get(0);
                    for (int i = 0; i < listaID.size(); i++) {
                        if (listaID.get(i) > IDMAYOR) {
                            IDMAYOR = listaID.get(i);
                        }
                    }
                    if(IDMAYOR>0){
                        String IDPH = prefijo+"-"+(IDMAYOR+1);
                        iGenerarID.GenerarID(IDPH);
                    }
                }else{
                    String IDPH = prefijo+"-"+1;
                    iGenerarID.GenerarID(IDPH);
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
            }
        });
    }

    public String IDCurrentUser(){
        FirebaseUser firebaseUser = FirebaseAuth.getInstance().getCurrentUser();
        return firebaseUser.getUid();
    }
}
