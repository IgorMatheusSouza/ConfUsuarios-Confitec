import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatTableModule, MatFormFieldModule, MatInputModule, MatProgressSpinnerModule, MatSelectModule, MatDatepickerModule, MatNativeDateModule, MAT_DATE_LOCALE } from '@angular/material';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './views/header/header.component';
import { HomeComponent } from './views/home/home.component';
import { ListaUsuariosComponent } from './views/usuario/lista-usuarios/lista-usuarios.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormUsuarioComponent } from './views/usuario/form-usuario/form-usuario.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NotifierModule } from 'angular-notifier';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { library } from '@fortawesome/fontawesome-svg-core';
import { faSquare } from '@fortawesome/free-solid-svg-icons';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    ListaUsuariosComponent,
    FormUsuarioComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatTableModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    MatProgressSpinnerModule,
    MatSelectModule,
    FormsModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    FontAwesomeModule,
    NotifierModule.withConfig({
      position: {
        horizontal: {
          position: 'middle',
          distance: 20
        },
        vertical: {
          position: 'top',
          distance: 20,
          gap: 10
        }
      },
      theme: 'material',
      behaviour: {
        autoHide: 7000,
        onClick: 'hide',
        onMouseover: 'pauseAutoHide',
        showDismissButton: true,
        stacking: 4
      },
      animations: {
        enabled: true,
        show: {
          preset: 'slide',
          speed: 300,
          easing: 'ease'
        },
        hide: {
          preset: 'fade',
          speed: 300,
          easing: 'ease',
          offset: 50
        },
        shift: {
          speed: 300,
          easing: 'ease'
        },
        overlap: 150
      }
    })
  ],
  providers: [{ provide: MAT_DATE_LOCALE, useValue: 'en-GB' }],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor() {
  }
}
