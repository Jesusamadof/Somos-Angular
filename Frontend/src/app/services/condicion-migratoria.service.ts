import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Endpoints } from '../environment/endpoints';
import { Observable } from 'rxjs';
import { CondicionMigratoria } from '../interfaces/condicion-migratoria';

@Injectable({
  providedIn: 'root'
})
export class CondicionMigratoriaService {


  api!:string;
  urlApi!:string;

  constructor(
    private http:HttpClient
   ) {
    this.api=Endpoints.urlApi;
    this.urlApi="/api/CondicionMigratoria"
    }

    getCondicionMigratoriaes(): Observable<any>{
      return this.http.get(this.api+this.urlApi);
    }

    getFiltroCondicionMigratoria(id:number): Observable<any>{
      return this.http.get(this.api+this.urlApi+`/${id}`);
    }

    postCondicionMigratoria(CondicionMigratoria:CondicionMigratoria): Observable<CondicionMigratoria>{
      return this.http.post<CondicionMigratoria>(this.api+this.urlApi,CondicionMigratoria);
    }

    putCondicionMigratoria(id:number, CondicionMigratoria:CondicionMigratoria): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/${id}`,CondicionMigratoria);
    }
    putEstadoCondicionMigratoria(id:number, CondicionMigratoria:CondicionMigratoria): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstado/${id}`,CondicionMigratoria);
    }

    putEliminarCondicionMigratoria(id:number, CondicionMigratoria:CondicionMigratoria): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstadoEliminacion/${id}`,CondicionMigratoria);
    }

}
