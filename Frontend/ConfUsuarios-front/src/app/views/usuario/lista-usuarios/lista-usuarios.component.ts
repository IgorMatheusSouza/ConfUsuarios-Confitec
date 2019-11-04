import { Component, OnInit } from '@angular/core';
import { UsuarioService } from 'src/app/services/usuario/usuario.service';
import { Usuario } from 'src/app/models/UsuarioModel';
import { escolaridade } from 'src/app/models/escolaridade.enum';

@Component({
  selector: 'app-lista-usuarios',
  templateUrl: './lista-usuarios.component.html',
  styleUrls: ['./lista-usuarios.component.scss']
})

export class ListaUsuariosComponent implements OnInit {

  constructor(private usuarioService: UsuarioService) { }
  usuarios: Usuario[];
  displayedColumns: string[] = ['img', 'nome', 'sobrenome', 'email', 'dataNascimento', 'escolaridade', 'acoes'];

  ngOnInit() {
    this.usuarioService.getUsuarios().subscribe(response => {
      this.usuarios = response;
    }, error => {

    });
  }

  formatarEscolaridade(valor: number) {
    return escolaridade[valor];
  }

  deletarUsuario(id: number) {
    this.usuarioService.deletarUsuario(id).subscribe(response => {
      this.usuarios = this.usuarios.filter(x => x.id !== id);
    }, error => {

    });
  }
}
