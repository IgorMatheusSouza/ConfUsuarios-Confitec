import { Component, OnInit, AfterViewInit } from '@angular/core';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, AfterViewInit {

  constructor() { }

  ngOnInit() {
  }

  // carrega animação na tela inicial
  ngAfterViewInit() {
    // tslint:disable-next-line: only-arrow-functions
    (function (document: any, tag: any) {
      const scriptTag: any = document.createElement(tag);
      const firstScriptTag: any = document.getElementsByTagName(tag)[0];
      scriptTag.src = 'assets/main.min.js';
      firstScriptTag.parentNode.insertBefore(scriptTag, firstScriptTag);
    }(document, 'script'));
  }
}
