import { Injectable } from '@angular/core';
import { Endpoints } from '../environment/endpoints';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Persona } from '../interfaces/persona';

@Injectable({
  providedIn: 'root'
})
export class PersonasService {


  api!:string;
  urlApi!:string;

  constructor(
    private http:HttpClient
   ) {
    this.api=Endpoints.urlApi;
    this.urlApi="/api/Personas"
    }

    getPersonas(): Observable<any>{
      return this.http.get(this.api+this.urlApi);
    }

    getFiltroPersona(id:number): Observable<any>{
      return this.http.get(this.api+this.urlApi+`/${id}`);
    }

    postPersona(Persona:Persona): Observable<Persona>{
      return this.http.post<Persona>(this.api+this.urlApi,Persona);
    }

    putPersona(id:number, Persona:Persona): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/${id}`,Persona);
    }
    putEstadoPersona(id:number, Persona:Persona): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstado/${id}`,Persona);
    }

    putEliminarPersona(id:number, Persona:Persona): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstadoEliminacion/${id}`,Persona);
    }


}
