package com.example.mian;

import androidx.annotation.NonNull;
import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.Bundle;
import android.util.Patterns;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

import com.example.mian.libreria.AngLib;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.android.material.textfield.TextInputEditText;
import com.google.firebase.auth.AuthResult;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;

public class LoginActivity extends AppCompatActivity {


    //::::: A N G E L :::: W R I T T E N :::: C O D E :::::

    private TextInputEditText txtICorreo,txtIPassword;
    private Button btIngresar;
    private ProgressDialog mDialog,mProgress;
    private FirebaseAuth mAut;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        AngLib.HiddeActionBar(this);
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        txtICorreo = findViewById(R.id.txtCorreo);
        txtIPassword = findViewById(R.id.txtPassword);
        btIngresar = findViewById(R.id.btIngresar);

        FirebaseUser user = FirebaseAuth.getInstance().getCurrentUser();

        if(user != null){
            txtICorreo.setText(user.getEmail());
        }

        btIngresar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                /*FirebaseAuth.getInstance().signOut();
                Intent intent = new Intent(LoginActivity.this,UserAddActivity.class);
                startActivity(intent);*/
                mDialog = AngLib.ShowProgressDialog(mProgress,LoginActivity.this);
                if(Validate()){
                    IniciarSesion(txtICorreo.getText().toString(),txtIPassword.getText().toString());
                }
            }
        });

        mAut = FirebaseAuth.getInstance();

    }

    private boolean Validate(){
        String email = txtICorreo.getText().toString().trim();
        String password = txtIPassword.getText().toString().trim();

        if(email.isEmpty() || !Patterns.EMAIL_ADDRESS.matcher(email).matches()){
            txtICorreo.setError("Email incorreto");
            return false;
        }else if(password.isEmpty()){
            txtIPassword.setError("Campo vacio");
            return false;
        }else{
            return true;
        }
    }

    private void IniciarSesion(String email,String password){
        mAut.signInWithEmailAndPassword(email,password)
                .addOnCompleteListener(new OnCompleteListener<AuthResult>() {
                    @Override
                    public void onComplete(@NonNull Task<AuthResult> task) {
                        if(task.isSuccessful()) {
                            mDialog.dismiss();
                            Intent intent = new Intent(LoginActivity.this,MainActivity.class);
                            startActivity(intent);
                            finish();
                        }else{
                            Toast.makeText(LoginActivity.this,"Credenciales no validos",Toast.LENGTH_SHORT).show();
                        }
                    }
                });
    }
}