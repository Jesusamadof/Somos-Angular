import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { TipoRelacion } from 'src/app/interfaces/tipo-relacion';
import { TipoRelacionService } from 'src/app/services/tipo-relacion.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-tipo-relacion',
  templateUrl: './tipo-relacion.component.html',
  styleUrls: ['./tipo-relacion.component.css']
})
export class TipoRelacionComponent {
  dats:any;
  displayedColumns: string[] = ['id', 'tipoRelacion', 'estado','editar','eliminar'];
  dataSource!: MatTableDataSource<TipoRelacion>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private _TipoRelacionService:TipoRelacionService,
    private router:Router
    ){

    }

    addEdit(id?:number){
      this.router.navigate([`home/mantenimientos/addEditTipoRelacion/${id}`]);
    }

    actualizarEstado(idTipoRelacion:number,estado:number){
      const lista:TipoRelacion={
        estado:estado
      }

      this._TipoRelacionService.putTipoRelacion(idTipoRelacion,lista).subscribe(res=>{
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
        this.getTipoRelacion();
      },err=>{
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
        });
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
          const lista:TipoRelacion={
            estadoEliminacion:1
          }
          this._TipoRelacionService.putEliminarTipoRelacion(id,lista).subscribe((res:any) => {
            if (res.ok) {

              swalWithBootstrapButtons.fire(
                'Eliminado!!',
                'El registro ha sido eliminado!',
                'success'
              )
              //window.location.reload();
              this.getTipoRelacion();

            } else {
              swalWithBootstrapButtons.fire(
                'Error!!',
                'No Se Pudo Eliminar!',
                'error'
              );
            }

          }, err=>{
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
            });
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
      });
    }







  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }





  getTipoRelacion(){
    this._TipoRelacionService.getTipoRelacion().subscribe(res=>{
      this.dats=res.lista;
      this.dataSource = new MatTableDataSource(this.dats);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;

    },err=>{
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
      });
    });
  }

  ngOnInit(): void {
    this.getTipoRelacion();
  }
}
