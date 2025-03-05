import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddEditRolComponent } from './seguridad/roles/add-edit-rol/add-edit-rol.component';
import { RolesComponent } from './seguridad/roles/roles.component';
import { UsuariosComponent } from './seguridad/usuarios/usuarios.component';
import {MatInputModule} from '@angular/material/input';
import {MatPaginatorModule} from '@angular/material/paginator';
import { MatSortModule} from '@angular/material/sort';
import { MatTableModule} from '@angular/material/table';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatIconModule} from '@angular/material/icon';
import {MatCardModule} from '@angular/material/card';
import { ReactiveFormsModule } from '@angular/forms';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import { ObjetosComponent } from './seguridad/objetos/objetos.component';
import { AddEditObjetoComponent } from './seguridad/objetos/add-edit-objeto/add-edit-objeto.component';
import { PreguntasComponent } from './seguridad/preguntas/preguntas.component';
import { AddEditPreguntaComponent } from './seguridad/preguntas/add-edit-pregunta/add-edit-pregunta.component';
import { AddEditUsuarioComponent } from './seguridad/usuarios/add-edit-usuario/add-edit-usuario.component';
import { PermisosComponent } from './seguridad/permisos/permisos.component';
import {CdkAccordionModule} from '@angular/cdk/accordion';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { VictimasComponent } from './gestion_personas/victimas/victimas.component';
import { AddEditVictimaComponent } from './gestion_personas/victimas/add-edit-victima/add-edit-victima.component';
import { OrientacionComponent } from './mantenimiento/orientacion/orientacion.component';
import { AddEditOrientacionComponent } from './mantenimiento/orientacion/add-edit-orientacion/add-edit-orientacion.component';
import { ParametrosComponent } from './seguridad/parametros/parametros.component';
import { AddEditParametroComponent } from './seguridad/parametros/add-edit-parametro/add-edit-parametro.component';
import { ModalidadComponent } from './mantenimiento/modalidad/modalidad.component';
import { AddEditModalidadComponent } from './mantenimiento/modalidad/add-edit-modalidad/add-edit-modalidad.component';
import { TipoVictimaComponent } from './mantenimiento/tipo-victima/tipo-victima.component';
import { AddEditTipoVictimaComponent } from './mantenimiento/tipo-victima/add-edit-tipo-victima/add-edit-tipo-victima.component';
import { CondicionMigratoriaComponent } from './mantenimiento/condicion-migratoria/condicion-migratoria.component';import { AddEditCondicionMigratoriaComponent } from './mantenimiento/condicion-migratoria/add-edit-condicion-migratoria/add-edit-condicion-migratoria.component';
import { EtniaComponent } from './mantenimiento/etnia/etnia.component';
import { AddEditEtniaComponent } from './mantenimiento/etnia/add-edit-etnia/add-edit-etnia.component';
import { ListaVictimasComponent } from './victimas/lista-victimas/lista-victimas.component';
import { AddEditVictiComponent } from './victimas/lista-victimas/add-edit-victi/add-edit-victi.component';
import { CasosComponent } from './gestion_casos/casos/casos.component';
import { AddEditCasoComponent } from './gestion_casos/casos/add-edit-caso/add-edit-caso.component';
import { TipoRelacionComponent } from './mantenimiento/tipo-relacion/tipo-relacion.component';
import { AddEditTipoRelacionComponent } from './mantenimiento/tipo-relacion/add-edit-tipo-relacion/add-edit-tipo-relacion.component';
import { HechoComponent } from './mantenimiento/hecho/hecho.component';
import { AddEditHechoComponent } from './mantenimiento/hecho/add-edit-hecho/add-edit-hecho.component';



@NgModule({
  declarations: [
    AddEditRolComponent,
    RolesComponent,
    UsuariosComponent,
    ObjetosComponent,
    AddEditObjetoComponent,
    PreguntasComponent,
    AddEditPreguntaComponent,
    AddEditUsuarioComponent,
    PermisosComponent,
    VictimasComponent,
    AddEditVictimaComponent,
    OrientacionComponent,
    AddEditOrientacionComponent,
    ParametrosComponent,
    AddEditParametroComponent,
    ModalidadComponent,
    AddEditModalidadComponent,
    TipoVictimaComponent,
    AddEditTipoVictimaComponent,
    CondicionMigratoriaComponent,
    AddEditCondicionMigratoriaComponent,
    EtniaComponent,
    AddEditEtniaComponent,
    ListaVictimasComponent,
    AddEditVictiComponent,
    CasosComponent,
    AddEditCasoComponent,
    TipoRelacionComponent,
    AddEditTipoRelacionComponent,
    HechoComponent,
    AddEditHechoComponent

  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatInputModule,
    MatFormFieldModule,
    MatSortModule,
    MatPaginatorModule,
    MatIconModule,
    MatCardModule,
    ReactiveFormsModule,
    MatSlideToggleModule,
    CdkAccordionModule,
    MatTooltipModule,
    MatCheckboxModule


  ]
})
export class PagesModule { }
