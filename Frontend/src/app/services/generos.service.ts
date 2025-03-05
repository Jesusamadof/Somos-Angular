import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Endpoints } from '../environment/endpoints';
import { Observable } from 'rxjs';
import { Genero } from '../interfaces/genero';

@Injectable({
  providedIn: 'root'
})
export class GenerosService {


  api!:string;
  urlApi!:string;

  constructor(
    private http:HttpClient
   ) {
    this.api=Endpoints.urlApi;
    this.urlApi="/api/GeneroVictima"
    }

    getGeneros(): Observable<any>{
      return this.http.get(this.api+this.urlApi);
    }

    getFiltroGenero(id:number): Observable<any>{
      return this.http.get(this.api+this.urlApi+`/${id}`);
    }

    postGenero(Genero:Genero): Observable<Genero>{
      return this.http.post<Genero>(this.api+this.urlApi,Genero);
    }

    putGenero(id:number, Genero:Genero): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/${id}`,Genero);
    }
    putEstadoGenero(id:number, Genero:Genero): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstado/${id}`,Genero);
    }

    putEliminarGenero(id:number, Genero:Genero): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstadoEliminacion/${id}`,Genero);
    }
}
