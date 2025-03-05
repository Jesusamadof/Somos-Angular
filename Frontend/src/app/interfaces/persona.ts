import { LugarDomicilio } from "./lugar-domicilio";
import { LugarNacimiento } from "./lugar-nacimiento";

export interface Persona {
  idPersona?: number;
  dni?: string;
  nombreLegal?: string;
  fechaNacimiento?: Date;
  estadoCivil?: string;
  agravantes?: string;
  nacionalidad?: string;
  telefono?: string;
  idNivelEduc?: number;
  fechaCreacion?: string;
  fechaModificacion?: string;
  idUsuarioCreo?: number;
  idUsuarioModifico?: number;
  estado?: number;
  estadoEliminacion?: number;
  tblLugarNacimientos?:LugarNacimiento[];
  tblLugarDomicilios?:LugarDomicilio[];
}
