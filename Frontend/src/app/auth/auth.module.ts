import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CambioContrasenaComponent } from './cambio-contrasena/cambio-contrasena.component';
import { RouterModule } from '@angular/router';
import { PreguntasUsuarioComponent } from './preguntas-usuario/preguntas-usuario.component';
import { RecuperarContrasenaComponent } from './recuperar-contrasena/recuperar-contrasena.component';
import {MatDialog, MAT_DIALOG_DATA, MatDialogRef, MatDialogModule} from '@angular/material/dialog';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatIconModule} from '@angular/material/icon';
import { RecuperarContraCorreoComponent } from './recuperar-contra-correo/recuperar-contra-correo.component';
import { RecuperarContraPreguntaComponent } from './recuperar-contra-pregunta/recuperar-contra-pregunta.component';


@NgModule({
  declarations: [
    LoginComponent,
    CambioContrasenaComponent,
    PreguntasUsuarioComponent,
    RecuperarContrasenaComponent,
    RecuperarContraCorreoComponent,
    RecuperarContraPreguntaComponent
  ],
  imports: [
    CommonModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    RouterModule,
    MatDialogModule,
    MatSelectModule,
    FormsModule,
    MatInputModule,
    MatSnackBarModule,
    MatIconModule
  ]
})
export class AuthModule { }
