import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  constructor(private route: Router,
    private _snackBar: MatSnackBar
    ) {

    }

    cerrarSesion() {

       const swalWithBootstrapButtons = Swal.mixin({
      customClass: {
      confirmButton: 'btn btn-success mr-8',
      cancelButton: 'btn btn-danger'
    },
    buttonsStyling: false
  })

  swalWithBootstrapButtons.fire({
    title: '¿Desea Cerrar Sesión?',
    icon: 'warning',
    showCancelButton: true,
    confirmButtonText: '   Si!  ',
    cancelButtonText: 'No!  ',
    reverseButtons: true
  }).then((result) => {
    if (result.isConfirmed) {
      this.route.navigate(['login']);
      localStorage.removeItem('token');
      localStorage.removeItem('activeRoutePadre');
      localStorage.removeItem('activeRouteHijo');
      localStorage.removeItem('tipoEstadoProveedor');

      swalWithBootstrapButtons.fire(
        'Sesión Cerrada!!',
        '',
        'info'
      )
    } else if (
      /* Read more about handling dismissals below */
      result.dismiss === Swal.DismissReason.cancel
    ) {
      swalWithBootstrapButtons.fire(
        'Cancelado!',
        'Su Sesion sigue activa! ' +'😊',
        'info',

      )
    }
  })
    }


  }


