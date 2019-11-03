import { Component, OnInit } from '@angular/core';
import { escolaridade } from 'src/app/models/escolaridade.enum';
import { UsuarioService } from 'src/app/services/usuario/usuario.service';
import { Usuario } from 'src/app/models/UsuarioModel';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-form-usuario',
  templateUrl: './form-usuario.component.html',
  styleUrls: ['./form-usuario.component.scss']
})

export class FormUsuarioComponent implements OnInit {
  valoresEscolaridade = Object.keys(escolaridade).filter(e => !isNaN(+e)).map(o => ({ index: +o, name: escolaridade[o] })); // Obtem os valores do enum escolaridade


  usuario = new FormGroup({
    nome: new FormControl(''),
    sobrenome: new FormControl(''),
    email: new FormControl(''),
    dataNascimento: new FormControl(''),
    escolaridade: new FormControl('')
  });

  constructor(private usuarioService: UsuarioService) { }

  ngOnInit() {
    console.log(this.valoresEscolaridade);
  }

  cadastrarUsuario() {
    this.usuarioService.cadastrarUsuario(this.usuario.value).subscribe(error => { });
  }
}
