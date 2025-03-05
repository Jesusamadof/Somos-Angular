import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Endpoints } from '../environment/endpoints';
import { Observable } from 'rxjs';
import { Caso } from '../interfaces/caso';

@Injectable({
  providedIn: 'root'
})
export class CasosService {

  api!:string;
  urlApi!:string;

  constructor(
    private http:HttpClient
   ) {
    this.api=Endpoints.urlApi;
    this.urlApi="/api/Casos"
    }

    getCasos(): Observable<any>{
      return this.http.get(this.api+this.urlApi);
    }

    getFiltroCaso(id:number): Observable<any>{
      return this.http.get(this.api+this.urlApi+`/${id}`);
    }

    postCaso(Caso:Caso): Observable<Caso>{
      return this.http.post<Caso>(this.api+this.urlApi,Caso);
    }

    putCaso(id:number, Caso:Caso): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/${id}`,Caso);
    }
    putEstadoCaso(id:number, Caso:Caso): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstado/${id}`,Caso);
    }

    putEliminarCaso(id:number, Caso:Caso): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstadoEliminacion/${id}`,Caso);
    }
}
