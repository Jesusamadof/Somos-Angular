import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { OrientacionSexual } from 'src/app/interfaces/orientacion-sexual';
import { OrientacionSexualService } from 'src/app/services/orientacion-sexual.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-orientacion',
  templateUrl: './orientacion.component.html',
  styleUrls: ['./orientacion.component.css']
})
export class OrientacionComponent implements OnInit{

  dats:any;
  displayedColumns: string[] = ['id', 'orientacionSexual', 'estado','editar','eliminar'];
  dataSource!: MatTableDataSource<OrientacionSexual>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private _orientacionSexualService:OrientacionSexualService,
    private router:Router
    ){

    }

    addEdit(id?:number){
      this.router.navigate([`home/mantenimientos/addEditOrientacion/${id}`]);
    }

    actualizarEstado(idRol:number,estado:number){
      const lista:OrientacionSexual={
        estado:estado
      }

      this._orientacionSexualService.putEstado(idRol,lista).subscribe(res=>{
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
        this.getOrientacion();
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
          const lista:OrientacionSexual={
            estadoEliminacion:1
          }
          this._orientacionSexualService.putEstadoEliminacion(id,lista).subscribe((res:any) => {
            if (res.ok) {

              swalWithBootstrapButtons.fire(
                'Eliminado!!',
                'El registro ha sido eliminado!',
                'success'
              )
              //window.location.reload();
              this.getOrientacion();

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





  getOrientacion(){
      this._orientacionSexualService.getOrientacion().subscribe(res=>{
        console.log(res)
      this.dats=res.lista;
      this.dataSource = new MatTableDataSource(this.dats);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;

      console.log(res);
    });
  }

  ngOnInit(): void {
    this.getOrientacion();
  }

}
