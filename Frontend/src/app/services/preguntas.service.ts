import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Endpoints } from '../environment/endpoints';
import { Observable } from 'rxjs';
import { Pregunta } from '../interfaces/pregunta';

@Injectable({
  providedIn: 'root'
})
export class PreguntasService {

  api!:string;
  urlApi!:string;

  constructor(
    private http:HttpClient
   ) {
    this.api=Endpoints.urlApi;
    this.urlApi="/api/Preguntas"
    }

    getPreguntas(): Observable<any>{
      return this.http.get(this.api+this.urlApi);
    }

    getPreguntasUsuario(id:number): Observable<any>{
      return this.http.get(this.api+this.urlApi+`/verificarPreguntasUsu/${id}`);
    }

    getFiltroPregunta(id:number): Observable<any>{
      return this.http.get(this.api+this.urlApi+`/${id}`);
    }

    postPregunta(Pregunta:Pregunta): Observable<Pregunta>{
      return this.http.post<Pregunta>(this.api+this.urlApi,Pregunta);
    }

    putPregunta(id:number, Pregunta:Pregunta): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/${id}`,Pregunta);
    }
    putEstadoPregunta(id:number, Pregunta:Pregunta): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstado/${id}`,Pregunta);
    }

    putEliminarPregunta(id:number, Pregunta:Pregunta): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstadoEliminacion/${id}`,Pregunta);
    }

}
