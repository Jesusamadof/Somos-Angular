import { Router } from '@angular/router';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-recuperar-contrasena',
  templateUrl: './recuperar-contrasena.component.html',
  styleUrls: ['./recuperar-contrasena.component.css']
})
export class RecuperarContrasenaComponent {
   form:FormGroup;
  constructor(
    public dialogRef: MatDialogRef<RecuperarContrasenaComponent>,
    private fb:FormBuilder,
    private router:Router
  ){
    this.form=fb.group({
      valor:['', [Validators.required]]
    })


  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  seleccionar(){
    if(this.form.value.valor==1){
      this.router.navigate(['auth/recuperarContrasenaCorreo'])

    }else{
      this.router.navigate(['auth/recuperarContrasenaPregunta'])

    }

  }

}
