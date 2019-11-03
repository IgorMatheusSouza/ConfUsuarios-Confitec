import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './views/home/home.component';
import { ListaUsuariosComponent } from './views/usuario/lista-usuarios/lista-usuarios.component';
import { FormUsuarioComponent } from './views/usuario/form-usuario/form-usuario.component';

const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'usuarios',
    component: ListaUsuariosComponent
  },
  {
    path: 'usuarios/cadastrar',
    component: FormUsuarioComponent
  },
  {
    path: 'usuarios/editar/:id',
    component: FormUsuarioComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
