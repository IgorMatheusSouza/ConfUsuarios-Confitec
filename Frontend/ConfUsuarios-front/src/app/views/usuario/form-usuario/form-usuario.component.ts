import { Component, OnInit } from '@angular/core';
import { escolaridade } from 'src/app/models/escolaridade.enum';
import { UsuarioService } from 'src/app/services/usuario/usuario.service';
import { Usuario } from 'src/app/models/UsuarioModel';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MAT_DATE_LOCALE } from '@angular/material';
import { NotifierService } from 'angular-notifier';

@Component({
  selector: 'app-form-usuario',
  templateUrl: './form-usuario.component.html',
  styleUrls: ['./form-usuario.component.scss']
})

export class FormUsuarioComponent implements OnInit {
  private idUsuario: number;
  valoresEscolaridade = Object.keys(escolaridade).filter(e => !isNaN(+e)).map(o => ({ index: +o, name: escolaridade[o] })); // Obtem os valores do enum escolaridade
  usuario = new FormGroup({
    id: new FormControl(0),
    nome: new FormControl(''),
    sobrenome: new FormControl(''),
    email: new FormControl(''),
    dataNascimento: new FormControl(''),
    escolaridade: new FormControl(''),
    imagem: new FormControl('https://cdn0.iconfinder.com/data/icons/users-16/16/person_minus-512.png')
  });


  constructor(private usuarioService: UsuarioService, private routeActive: ActivatedRoute, private router: Router, private notifierService: NotifierService) { }

  ngOnInit() {
    this.idUsuario = parseInt(this.routeActive.snapshot.paramMap.get('id'), 10);

    if (this.idUsuario) {
      this.usuarioService.getUsuario(this.idUsuario).subscribe(result => {
        this.usuario.patchValue(result as Usuario);
      }, error => {
        this.notifierService.show({ type: 'error', message: 'Opps! ' + error.error });
      });
    }
  }

  salvarUsuario() {
    if (this.idUsuario) {
      this.atualizarUsuario();
    } else {
      this.cadastrarUsuario();
    }
  }

  private cadastrarUsuario() {
    this.usuarioService.cadastrarUsuario(this.usuario.value).subscribe(response => {
      this.notifierService.show({ type: 'success', message: 'Bom trabalho! Os dados foram cadastrar!' });
      this.router.navigateByUrl('/usuarios');
    }, error => {
      this.notifierService.show({ type: 'error', message: 'Opps! ' + error.error });
    });
  }

  private atualizarUsuario() {
    this.usuarioService.atualizarUsuario(this.usuario.value).subscribe(response => {
      this.notifierService.show({ type: 'success', message: 'Bom trabalho! Os dados foram salvos!' });
      this.router.navigateByUrl('/usuarios');
    }, error => {
      console.log(error);
      this.notifierService.show({ type: 'error', message: 'Opps! ' + error.error });
    });
  }
}
