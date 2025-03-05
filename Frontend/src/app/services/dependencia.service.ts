import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Endpoints } from '../environment/endpoints';
import { Observable } from 'rxjs';
import { Dependencia } from '../interfaces/dependencia';

@Injectable({
  providedIn: 'root'
})
export class DependenciaService {


  api!:string;
  urlApi!:string;

  constructor(
    private http:HttpClient
   ) {
    this.api=Endpoints.urlApi;
    this.urlApi="/api/Dependencias"
    }

    getDependencias(): Observable<any>{
      return this.http.get(this.api+this.urlApi);
    }

    getFiltroDependencia(id:number): Observable<any>{
      return this.http.get(this.api+this.urlApi+`/${id}`);
    }

    postDependencia(Dependencia:Dependencia): Observable<Dependencia>{
      return this.http.post<Dependencia>(this.api+this.urlApi,Dependencia);
    }

    putDependencia(id:number, Dependencia:Dependencia): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/${id}`,Dependencia);
    }
    putEstadoDependencia(id:number, Dependencia:Dependencia): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstado/${id}`,Dependencia);
    }

    putEliminarDependencia(id:number, Dependencia:Dependencia): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstadoEliminacion/${id}`,Dependencia);
    }
}
