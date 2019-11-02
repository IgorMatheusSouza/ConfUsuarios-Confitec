import { Component, OnInit } from '@angular/core';
import { UsuarioService } from 'src/app/services/usuario/usuario.service';
import { Usuario } from 'src/app/models/UsuarioModel';

@Component({
  selector: 'app-lista-usuarios',
  templateUrl: './lista-usuarios.component.html',
  styleUrls: ['./lista-usuarios.component.scss']
})
export class ListaUsuariosComponent implements OnInit {

  constructor(private usuarioService: UsuarioService) { }
  usuarios: Usuario[];

  ngOnInit() {
    this.usuarioService.getUsuarios().subscribe(response => {
      this.usuarios = response;
    }, error => {

    });
  }
}
