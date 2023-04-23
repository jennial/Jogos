import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { JogosComponent } from './components/jogos/jogos.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './components/nav/nav.component';
import {CollapseModule} from 'ngx-bootstrap/collapse';
import { FormsModule } from '@angular/forms';
import { TituloComponent } from './components/titulo/titulo.component';
import { CadastroGeneroComponent } from './components/cadastroGenero/cadastroGenero.component';
import { CadastroJogoComponent } from './components/cadastroJogo/cadastroJogo.component';


@NgModule({
  declarations: [
    AppComponent,
    JogosComponent,
    NavComponent,
    TituloComponent,
    CadastroGeneroComponent,
    CadastroJogoComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
