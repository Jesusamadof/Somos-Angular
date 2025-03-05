import { Injectable } from '@angular/core';
import { Endpoints } from '../environment/endpoints';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ExpresionGenero } from '../interfaces/expresion-genero';

@Injectable({
  providedIn: 'root'
})
export class ExpresionGeneroService {


  api!:string;
  urlApi!:string;

  constructor(
    private http:HttpClient
   ) {
    this.api=Endpoints.urlApi;
    this.urlApi="/api/ExpresionGenero"
    }

    getExpresionGeneros(): Observable<any>{
      return this.http.get(this.api+this.urlApi);
    }

    getFiltroExpresionGenero(id:number): Observable<any>{
      return this.http.get(this.api+this.urlApi+`/${id}`);
    }

    postExpresionGenero(ExpresionGenero:ExpresionGenero): Observable<ExpresionGenero>{
      return this.http.post<ExpresionGenero>(this.api+this.urlApi,ExpresionGenero);
    }

    putExpresionGenero(id:number, ExpresionGenero:ExpresionGenero): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/${id}`,ExpresionGenero);
    }
    putEstadoExpresionGenero(id:number, ExpresionGenero:ExpresionGenero): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstado/${id}`,ExpresionGenero);
    }

    putEliminarExpresionGenero(id:number, ExpresionGenero:ExpresionGenero): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstadoEliminacion/${id}`,ExpresionGenero);
    }
}
