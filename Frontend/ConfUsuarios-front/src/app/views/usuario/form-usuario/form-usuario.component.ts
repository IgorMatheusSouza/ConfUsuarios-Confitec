import { Component, OnInit } from '@angular/core';
import { escolaridade } from 'src/app/models/escolaridade.enum';
import { UsuarioService } from 'src/app/services/usuario/usuario.service';
import { Usuario } from 'src/app/models/UsuarioModel';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

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

  constructor(private usuarioService: UsuarioService, private route: ActivatedRoute) { }

  ngOnInit() {
    const id = parseInt(this.route.snapshot.paramMap.get('id'), 10);
    if (id) {
      this.usuarioService.getUsuario(id).subscribe(result => {
        this.usuario.patchValue(result as Usuario);
      });
    }
  }

  cadastrarUsuario() {
    this.usuarioService.cadastrarUsuario(this.usuario.value).subscribe(error => { });
  }
}
