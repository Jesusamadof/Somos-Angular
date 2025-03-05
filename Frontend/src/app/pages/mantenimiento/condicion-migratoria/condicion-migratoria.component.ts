import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { CondicionMigratoria } from 'src/app/interfaces/condicion-migratoria';
import { CondicionMigratoriaService } from 'src/app/services/condicion-migratoria.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-condicion-migratoria',
  templateUrl: './condicion-migratoria.component.html',
  styleUrls: ['./condicion-migratoria.component.css']
})
export class CondicionMigratoriaComponent implements OnInit {

  dats:any;
  displayedColumns: string[] = ['id', 'condicion', 'estado','editar','eliminar'];
  dataSource!: MatTableDataSource<CondicionMigratoria>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private _condicionMigrService:CondicionMigratoriaService,
    private router:Router
    ){

    }

    addEdit(id?:number){
      this.router.navigate([`home/mantenimientos/addEditCondicionMigratoria/${id}`]);
    }



    actualizarEstado(idRol:number,estado:number){
      const lista:CondicionMigratoria={
        estado:estado
      }

      this._condicionMigrService.putEstadoCondicionMigratoria(idRol,lista).subscribe(res=>{
        console.log('res: ', res);
        const Toast = Swal.mixin({
          toast: true,
          position: 'top-end',
          showConfirmButton: false,
          width:500,
          timer: 7000,
          timerProgressBar: true,
          didOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer)
            toast.addEventListener('mouseleave', Swal.resumeTimer)
          }
        })

        Toast.fire({
          icon: 'success',
          title: `Cambio Exitoso!!`
        })
        this.getCondicionMig();
      });
    }

    borrar(id:number){
      const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
          confirmButton: 'btn btn-success mr-8',
          cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false
      })

      swalWithBootstrapButtons.fire({
        title: '¿Desea Eliminar el Registro?',
        text: "Recuerde que no podra recuperar el registro!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Si, Eliminar!  ',
        cancelButtonText: 'No, cancelar!  ',
        reverseButtons: true
      }).then((result) => {
        if (result.isConfirmed) {
          const lista:CondicionMigratoria={
            estadoEliminacion:1
          }
          this._condicionMigrService.putEliminarCondicionMigratoria(id,lista).subscribe((res:any) => {
            if (res.ok) {

              swalWithBootstrapButtons.fire(
                'Eliminado!!',
                'El registro ha sido eliminado!',
                'success'
              )
              //window.location.reload();
              this.getCondicionMig();

            } else {
              swalWithBootstrapButtons.fire(
                'Error!!',
                'No Se Pudo Eliminar!',
                'error'
              );
            }

          });

        } else if (
          /* Read more about handling dismissals below */
          result.dismiss === Swal.DismissReason.cancel
        ) {
          swalWithBootstrapButtons.fire(
            'Cancelado!',
            'El registro no se elimino :)',
            'error'
          )
        }
      }, error => {
        const Toast = Swal.mixin({
          toast: true,
          position: 'top-end',
          showConfirmButton: false,
          width:500,
          timer: 7000,
          timerProgressBar: true,
          didOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer)
            toast.addEventListener('mouseleave', Swal.resumeTimer)
          }
        })

        Toast.fire({
          icon: 'error',
          title: `Error de Servidor. Intente nuevamente!!`
        })
      })





    }







  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }





  getCondicionMig(){
      this._condicionMigrService.getCondicionMigratoriaes().subscribe(res=>{
        console.log(res)
      this.dats=res.lista;
      this.dataSource = new MatTableDataSource(this.dats);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;

      console.log(res);
    });
  }

  ngOnInit(): void {
    this.getCondicionMig();
  }

}
