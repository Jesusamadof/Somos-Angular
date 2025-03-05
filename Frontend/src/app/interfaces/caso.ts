import { Time } from "@angular/common";

export interface Caso {
  idCaso?: number;
  fecha?: Date;
  hora?: string;
  lugar?: string;
  nombreGenero?: string;
  alias?: string;
  dni?: string;
  idOrientacion?: number;
  otroNombre?:string;
  fechaCreacion?: Date;
  fechaModificacion?: Date;
  idUsuarioCreo?: number;
  idUsuarioModifico?: number;
  estado?: number;
  estadoEliminacion?: number;
}
