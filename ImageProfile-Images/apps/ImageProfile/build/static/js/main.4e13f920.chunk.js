(this["webpackJsonpmy-app"]=this["webpackJsonpmy-app"]||[]).push([[0],{16:function(e,t,n){},2:function(e,t,n){e.exports={row:"Counter_row__13511",value:"Counter_value__1Ggcg",button:"Counter_button__RLnQX",textbox:"Counter_textbox__pzqjN",asyncButton:"Counter_asyncButton__2RpiV Counter_button__RLnQX"}},23:function(e,t,n){},24:function(e,t,n){"use strict";n.r(t);var r=n(0),a=n.n(r),c=n(5),o=n.n(c),s=(n(16),n.p+"static/media/logo.db36153e.svg"),u=n(11),i=n(3),l=i.c,d=n(9),j=n.n(d),b=n(10),p=n(4);function h(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:1;return new Promise((function(t){return setTimeout((function(){return t({data:e})}),500)}))}var m=Object(p.b)("counter/fetchCount",function(){var e=Object(b.a)(j.a.mark((function e(t){var n;return j.a.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return e.next=2,h(t);case 2:return n=e.sent,e.abrupt("return",n.data);case 4:case"end":return e.stop()}}),e)})));return function(t){return e.apply(this,arguments)}}()),x=Object(p.c)({name:"counter",initialState:{value:0,status:"idle"},reducers:{increment:function(e){e.value+=1},decrement:function(e){e.value-=1},incrementByAmount:function(e,t){e.value+=t.payload}},extraReducers:function(e){e.addCase(m.pending,(function(e){e.status="loading"})).addCase(m.fulfilled,(function(e,t){e.status="idle",e.value+=t.payload}))}}),f=x.actions,O=f.increment,v=f.decrement,g=f.incrementByAmount,_=function(e){return e.counter.value},k=x.reducer,N=n(2),w=n.n(N),A=n(1);function C(){var e=l(_),t=Object(i.b)(),n=Object(r.useState)("2"),a=Object(u.a)(n,2),c=a[0],o=a[1],s=Number(c)||0;return Object(A.jsxs)("div",{children:[Object(A.jsxs)("div",{className:w.a.row,children:[Object(A.jsx)("button",{className:w.a.button,"aria-label":"Decrement value",onClick:function(){return t(v())},children:"-"}),Object(A.jsx)("span",{className:w.a.value,children:e}),Object(A.jsx)("button",{className:w.a.button,"aria-label":"Increment value",onClick:function(){return t(O())},children:"+"})]}),Object(A.jsxs)("div",{className:w.a.row,children:[Object(A.jsx)("input",{className:w.a.textbox,"aria-label":"Set increment amount",value:c,onChange:function(e){return o(e.target.value)}}),Object(A.jsx)("button",{className:w.a.button,onClick:function(){return t(g(s))},children:"Add Amount"}),Object(A.jsx)("button",{className:w.a.asyncButton,onClick:function(){return t(m(s))},children:"Add Async"}),Object(A.jsx)("button",{className:w.a.button,onClick:function(){return t((e=s,function(t,n){_(n())%2===1&&t(g(e))}));var e},children:"Add If Odd"})]})]})}n(23);var y=function(){return Object(A.jsx)("div",{className:"App",children:Object(A.jsxs)("header",{className:"App-header",children:[Object(A.jsx)("img",{src:s,className:"App-logo",alt:"logo"}),Object(A.jsx)(C,{}),Object(A.jsxs)("p",{children:["Edit ",Object(A.jsx)("code",{children:"src/App.tsx"})," and save to reload."]}),Object(A.jsxs)("span",{children:[Object(A.jsx)("span",{children:"Learn "}),Object(A.jsx)("a",{className:"App-link",href:"https://reactjs.org/",target:"_blank",rel:"noopener noreferrer",children:"React"}),Object(A.jsx)("span",{children:", "}),Object(A.jsx)("a",{className:"App-link",href:"https://redux.js.org/",target:"_blank",rel:"noopener noreferrer",children:"Redux"}),Object(A.jsx)("span",{children:", "}),Object(A.jsx)("a",{className:"App-link",href:"https://redux-toolkit.js.org/",target:"_blank",rel:"noopener noreferrer",children:"Redux Toolkit"}),",",Object(A.jsx)("span",{children:" and "}),Object(A.jsx)("a",{className:"App-link",href:"https://react-redux.js.org/",target:"_blank",rel:"noopener noreferrer",children:"React Redux"})]})]})})},R=Object(p.a)({reducer:{counter:k}});Boolean("localhost"===window.location.hostname||"[::1]"===window.location.hostname||window.location.hostname.match(/^127(?:\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}$/));o.a.render(Object(A.jsx)(a.a.StrictMode,{children:Object(A.jsx)(i.a,{store:R,children:Object(A.jsx)(y,{})})}),document.getElementById("root")),"serviceWorker"in navigator&&navigator.serviceWorker.ready.then((function(e){e.unregister()})).catch((function(e){console.error(e.message)}))}},[[24,1,2]]]);
//# sourceMappingURL=main.4e13f920.chunk.js.map