import { Permiso } from "./permiso";

export interface Rol {
  idRol?:number;
  nombreRol?:string;
  descripcion?:string;
  estado?:number;
  estadoEliminacion?:number;
  tblPermisos?:Permiso[];
}
