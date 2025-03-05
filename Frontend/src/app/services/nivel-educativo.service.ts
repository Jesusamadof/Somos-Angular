import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Endpoints } from '../environment/endpoints';
import { Observable } from 'rxjs';
import { NivelEducativo } from '../interfaces/nivel-educativo';

@Injectable({
  providedIn: 'root'
})
export class NivelEducativoService {

  api!:string;
  urlApi!:string;

  constructor(
    private http:HttpClient
   ) {
    this.api=Endpoints.urlApi;

    this.urlApi="/api/NivelEducativo"
    }

    getNivelEducativos(): Observable<any>{
      return this.http.get(this.api+this.urlApi);
    }

    getFiltroNivelEducativo(id:number): Observable<any>{
      return this.http.get(this.api+this.urlApi+`/${id}`);
    }

    postNivelEducativo(nivelEducativo:NivelEducativo): Observable<NivelEducativo>{
      return this.http.post<NivelEducativo>(this.api+this.urlApi,nivelEducativo);
    }

    putNivelEducativo(id:number, nivelEducativo:NivelEducativo): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/${id}`,nivelEducativo);
    }
    putEstadoNivelEducativo(id:number, nivelEducativo:NivelEducativo): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstado/${id}`,nivelEducativo);
    }

    putEliminarNivelEducativo(id:number, nivelEducativo:NivelEducativo): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstadoEliminacion/${id}`,nivelEducativo);
    }

}
