import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Endpoints } from '../environment/endpoints';
import { Observable } from 'rxjs';
import { Usuario } from '../interfaces/usuario';
import { PreguntasUsuario } from '../interfaces/preguntas-usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  api!:string;
  urlApi!:string;
  urlApiPreguntas!:string;

  constructor(
    private http:HttpClient
   ) {
    this.api=Endpoints.urlApi;
    this.urlApi="/api/Usuarios"
    this.urlApiPreguntas="/api/PreguntasUsuario"
    }

    getUsuarios(): Observable<any>{
      return this.http.get(this.api+this.urlApi);
    }

    getFiltroUsuario(id:number): Observable<any>{
      return this.http.get(this.api+this.urlApi+`/${id}`);
    }

    postUsuario(Usuario:Usuario): Observable<Usuario>{
      return this.http.post<Usuario>(this.api+this.urlApi,Usuario);
    }

    putUsuario(id:number, Usuario:Usuario): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/${id}`,Usuario);
    }
    putEstadoUsuario(id:number, Usuario:Usuario): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstado/${id}`,Usuario);
    }

    putEliminarUsuario(id:number, Usuario:Usuario): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstadoEliminacion/${id}`,Usuario);
    }

    cambioContrasena(id:number, datos:any): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/cambiarContrasena/${id}`,datos)
    }

    postPreguntasUsuario(lista:PreguntasUsuario): Observable<PreguntasUsuario[]>{

      return this.http.post<PreguntasUsuario[]>(this.api+this.urlApiPreguntas+`/preguntasUsuario`,lista);

    }
    postRespuestaPreguntasUsuario(lista:any): Observable<PreguntasUsuario[]>{
      return this.http.post<PreguntasUsuario[]>(this.api+this.urlApiPreguntas+`/verificarRespuesta`,lista);

    }

    getFiltroPreguntasUsuario(usuario:string): Observable<any>{
      return this.http.get(this.api+this.urlApiPreguntas+`/${usuario}`);
    }

}
