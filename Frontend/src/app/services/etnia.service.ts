import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Endpoints } from '../environment/endpoints';
import { Observable } from 'rxjs';
import { Etnia } from '../interfaces/etnia';

@Injectable({
  providedIn: 'root'
})
export class EtniaService {


  api!:string;
  urlApi!:string;

  constructor(
    private http:HttpClient
   ) {
    this.api=Endpoints.urlApi;
    this.urlApi="/api/Etnia"
    }

    getEtniaes(): Observable<any>{
      return this.http.get(this.api+this.urlApi);
    }

    getFiltroEtnia(id:number): Observable<any>{
      return this.http.get(this.api+this.urlApi+`/${id}`);
    }

    postEtnia(Etnia:Etnia): Observable<Etnia>{
      return this.http.post<Etnia>(this.api+this.urlApi,Etnia);
    }

    putEtnia(id:number, Etnia:Etnia): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/${id}`,Etnia);
    }
    putEstadoEtnia(id:number, Etnia:Etnia): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstado/${id}`,Etnia);
    }

    putEliminarEtnia(id:number, Etnia:Etnia): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstadoEliminacion/${id}`,Etnia);
    }

}
