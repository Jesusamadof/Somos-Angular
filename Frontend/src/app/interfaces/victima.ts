import { DependienteVictima } from './dependiente-victima';
import { OrganizacionVictima } from './organizacion-victima';
export interface Victima {
  idVictima?: number;
  idPersona?: number;
  nombreLegal?: string;
  cambioNomLegalVictima?: string;
  nombreIdentGenero?: string;
  otroNombres?: string;
  idGeneroVictima?: number;
  idExpresionGenero?: number;
  idOrientacion?: number;
  ocupacion?: string;
  discapacidadVictima?: number;
  idCondicionMigratoria?: number;
  idEtnia?: number;
  hijos?: number;
  cantHijos?: number;
  cantHijosMen?: number;
  cantHijosMay?: number;
  cantPersDependiente?: number;
  pertenecienteOrganizacion?: number;
  denuciaPrevia?: number;
  numeroCaso?: number;
  tipoDenucia?: string;
  nomInstiDenucia?: string;
  medidasProteccion?: string;
  tipoMedProteccion?: string;
  idGeneradorHecho?: number;
  fechaModificacion?: Date;
  idUsuarioCreo?: number;
  idUsuarioModifico?: number;
  estado?: number;
  estadoEliminacion?: number;
  tblDetDepenVictimas?:DependienteVictima[];
  tblDetOrganVictimas?:OrganizacionVictima[];
}
