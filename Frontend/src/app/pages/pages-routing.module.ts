import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsuariosComponent } from './seguridad/usuarios/usuarios.component';
import { RolesComponent } from './seguridad/roles/roles.component';
import { RouterModule, Routes } from '@angular/router';
import { ContentComponent } from '../shared/content/content.component';
import { AddEditRolComponent } from './seguridad/roles/add-edit-rol/add-edit-rol.component';
import { ObjetosComponent } from './seguridad/objetos/objetos.component';
import { AddEditObjetoComponent } from './seguridad/objetos/add-edit-objeto/add-edit-objeto.component';
import { PreguntasComponent } from './seguridad/preguntas/preguntas.component';
import { AddEditPreguntaComponent } from './seguridad/preguntas/add-edit-pregunta/add-edit-pregunta.component';
import { AddEditUsuarioComponent } from './seguridad/usuarios/add-edit-usuario/add-edit-usuario.component';
import { PermisosComponent } from './seguridad/permisos/permisos.component';
import { DashboardComponent } from '../shared/dashboard/dashboard.component';
import { AddEditVictimaComponent } from './gestion_personas/victimas/add-edit-victima/add-edit-victima.component';
import { VictimasComponent } from './gestion_personas/victimas/victimas.component';
import { ParametrosComponent } from './seguridad/parametros/parametros.component';
import { OrientacionComponent } from './mantenimiento/orientacion/orientacion.component';
import { AddEditOrientacionComponent } from './mantenimiento/orientacion/add-edit-orientacion/add-edit-orientacion.component';
import { AddEditModalidadComponent } from './mantenimiento/modalidad/add-edit-modalidad/add-edit-modalidad.component';
import { ModalidadComponent } from './mantenimiento/modalidad/modalidad.component';
import { AddEditTipoVictimaComponent } from './mantenimiento/tipo-victima/add-edit-tipo-victima/add-edit-tipo-victima.component';
import { TipoVictimaComponent } from './mantenimiento/tipo-victima/tipo-victima.component';
import { ListaVictimasComponent } from './victimas/lista-victimas/lista-victimas.component';
import { AddEditVictiComponent } from './victimas/lista-victimas/add-edit-victi/add-edit-victi.component';
import { AddEditCondicionMigratoriaComponent } from './mantenimiento/condicion-migratoria/add-edit-condicion-migratoria/add-edit-condicion-migratoria.component';
import { CondicionMigratoriaComponent } from './mantenimiento/condicion-migratoria/condicion-migratoria.component';
import { EtniaComponent } from './mantenimiento/etnia/etnia.component';
import { AddEditEtniaComponent } from './mantenimiento/etnia/add-edit-etnia/add-edit-etnia.component';
import { CasosComponent } from './gestion_casos/casos/casos.component';
import { AddEditCasoComponent } from './gestion_casos/casos/add-edit-caso/add-edit-caso.component';
import { TipoRelacionComponent } from './mantenimiento/tipo-relacion/tipo-relacion.component';
import { AddEditTipoRelacionComponent } from './mantenimiento/tipo-relacion/add-edit-tipo-relacion/add-edit-tipo-relacion.component';

const Routes:Routes=[
  {path:'home',component:ContentComponent,children:[
    //Rutas hijas
    {path:'dashboard', component:DashboardComponent},
    {path:'seguridad',children:[
      {path:'usuarios',component:UsuariosComponent},
      {path:'roles',component:RolesComponent},
      {path:'addEditRol/:id',component:AddEditRolComponent},
      {path:'objetos', component:ObjetosComponent},
      {path:'addEditObjeto/:id', component:AddEditObjetoComponent},
      {path:'preguntas', component:PreguntasComponent},
      {path:'addEditPregunta/:id', component:AddEditPreguntaComponent},
      {path:'addEditUsuario/:id', component:AddEditUsuarioComponent},
      {path:'permisos', component:PermisosComponent},
      {path:'parametros', component:ParametrosComponent},


    ]},
    {path:'gestionPersonas', children:[
      {path:'victimas', component:VictimasComponent},
      {path:'addEditVictima/:id', component:AddEditVictimaComponent}

    ]},
    {path:'gestionPersonas', children:[
      {path:'personas', component:VictimasComponent},
      {path:'addEditVictima/:id', component:AddEditVictimaComponent}
    ]},
    {path:'victimas', children:[
      {path:'lista_victimas', component:ListaVictimasComponent},
      {path:'addEditVictima/:id', component:AddEditVictiComponent}
    ]},
    {path:'mantenimientos', children:[
      {path:'orientacion_sexual', component:OrientacionComponent},
      {path:'addEditOrientacion/:id',component:AddEditOrientacionComponent},
      {path:'condicion_migratoria', component:CondicionMigratoriaComponent},
      {path:'addEditCondicionMigratoria/:id',component:AddEditCondicionMigratoriaComponent},
      {path:'etnias',component:EtniaComponent},
      {path:'addEditEtnia/:id',component:AddEditEtniaComponent},
      {path:'modalidades',component:ModalidadComponent},
      {path:'addEditModalidad/:id',component:AddEditModalidadComponent},
      {path:'tipovictima',component:TipoVictimaComponent},
      {path:'addEditTipoVictima/:id',component:AddEditTipoVictimaComponent},
      {path:'tiporelacion',component:TipoRelacionComponent},
      {path:'addEditTipoRelacion/:id',component:AddEditTipoRelacionComponent}
    ]},
    {path:'casos', children:[
      {path:'lista_casos', component:CasosComponent},
      {path:'addEditCaso/:id',component:AddEditCasoComponent},

    ]}
  ]}]



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(Routes)
  ]
})
export class PagesRoutingModule { }
