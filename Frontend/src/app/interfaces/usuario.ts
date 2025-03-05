import { PreguntasUsuario } from "./preguntas-usuario";

export interface Usuario {
  idUsuario?:number;
  nombre?:string;
  correo?:string;
  usuario?:string;
  contrasena?:string;
  cambioContrasena?:number;
  contrasenaSegura?:number;
  estado?:number;
  estadoEliminacion?:number;
  idRol?:number;
  tblPreguntaUsuarios?:PreguntasUsuario[]
}
