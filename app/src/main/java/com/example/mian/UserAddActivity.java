package com.example.mian;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

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

import java.util.regex.Pattern;

public class UserAddActivity extends AppCompatActivity {

    //::::: A N G E L :::: W R I T T E N :::: C O D E :::::
    TextInputEditText txtICorreo,txtIPassword,txtIPasswordConfirmar;
    Button btGuardar,btCancelar;

    private FirebaseAuth mAuth;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        AngLib.HiddeActionBar(this);
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user_add);

        txtICorreo = findViewById(R.id.txtICorreo);
        txtIPassword = findViewById(R.id.txtIPassword);
        txtIPasswordConfirmar = findViewById(R.id.txtIPasswordConfirmar);
        btGuardar = findViewById(R.id.btGuardarUsuario);
        btCancelar = findViewById(R.id.btRegresarUsuario);

        btGuardar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Validate();
            }
        });

        mAuth = FirebaseAuth.getInstance();
    }

    private void Validate(){
        String correo = txtICorreo.getText().toString().trim();
        String password = txtIPassword.getText().toString().trim();
        String passwordConfirmar = txtIPasswordConfirmar.getText().toString().trim();

        if(correo.isEmpty() || !Patterns.EMAIL_ADDRESS.matcher(correo).matches()){
            txtICorreo.setError("Correo invalido");
        }

        if(password.isEmpty() || password.length() < 8){
            txtIPassword.setError("Se necesita mas de 8 caracteres");
        }else if(!Pattern.compile("[0-9]]").matcher(password).find()){
            txtIPassword.setError("Almenos un numero");
        }

        if(!passwordConfirmar.equals(password)){
            txtIPasswordConfirmar.setError("La contraseña no coinside");
        }else{
            Registrar(correo,password);
        }
    }

    private void Registrar(String email,String password){

        mAuth.createUserWithEmailAndPassword(email,password)
                .addOnCompleteListener(UserAddActivity.this, new OnCompleteListener<AuthResult>() {
                    @Override
                    public void onComplete(@NonNull Task<AuthResult> task) {
                        if(task.isSuccessful()){
                            Intent intent = new Intent(UserAddActivity.this,LoginActivity.class);
                            startActivity(intent);
                            finish();
                        }else{
                            Toast.makeText(UserAddActivity.this,"Fallo en el registro",Toast.LENGTH_SHORT).show();
                        }
                    }
                });
    }
}