export interface GeneradorHecho {
  idGeneradorHecho?: number;
  idFuenteDato?: number;
  nombLlenadorDato?: string;
  fechaLlenadoDato?: Date;
  intitucionRecoDato?: string;
  cargoDentroOrganizacion?: string;
  nombSupervisor?: string;
  fechaCreacion?: Date;
  fechaModificacion?: Date;
  idUsuarioCreo?: number;
  idUsuarioModifico?: number;
  estado?: number;
  estadoEliminacion?: number;
}
