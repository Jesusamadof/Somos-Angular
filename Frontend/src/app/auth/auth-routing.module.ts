import {  NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {  RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { CambioContrasenaComponent } from './cambio-contrasena/cambio-contrasena.component';
import { PreguntasUsuarioComponent } from './preguntas-usuario/preguntas-usuario.component';
import { RecuperarContraCorreoComponent } from './recuperar-contra-correo/recuperar-contra-correo.component';
import { RecuperarContraPreguntaComponent } from './recuperar-contra-pregunta/recuperar-contra-pregunta.component';

const routes:Routes=[
  {path:'', redirectTo:'login', pathMatch:'full'},
  {path:'login',component:LoginComponent},
  {path:'auth', children:[
    {path:'cambiarContrasena/:id/:usuario/:nombre', component:CambioContrasenaComponent},
    {path:'preguntasUsuario/:id/:usuario/:nombre', component:PreguntasUsuarioComponent},
    {path:'recuperarContrasenaCorreo',component:RecuperarContraCorreoComponent},
    {path:'recuperarContrasenaPregunta',component:RecuperarContraPreguntaComponent},
  ]}
]
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ]
})
export class AuthRoutingModule { }
