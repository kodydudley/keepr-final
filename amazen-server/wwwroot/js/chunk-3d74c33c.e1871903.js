(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-3d74c33c"],{"156e":function(e,t,c){"use strict";c("57d0")},"1a3e":function(e,t,c){"use strict";c.r(t);var s=c("7a23");const l=Object(s["K"])("data-v-39695338");Object(s["u"])("data-v-39695338");const a={class:"about container-fluid"},o={class:"row mt-5"},r={class:"col-3 text-center my-auto"},i={class:"col-8"},n={class:"row"},b={class:"header-text"},d={class:"row"},p={class:"subheader-text"},j={class:"row"},O={class:"subheader-text"},f={class:"row mt-5"},u={class:"col-10 offset-1 d-flex"},v=Object(s["h"])("div",{class:"section-header"}," Vaults ",-1),h={class:"col-10 offset-1 mt-5"},m={class:"card-columns"},w={class:"row mt-5 "},K={class:"col-10 offset-1 d-flex"},P=Object(s["h"])("div",{class:"section-header"}," Keeps ",-1),V={class:"col-10 offset-1 mt-5"},k={class:"card-columns"};Object(s["s"])();const x=l((function(e,t,c,l,x,y){const C=Object(s["y"])("create-vault-component"),g=Object(s["y"])("profileVaultsComponent"),I=Object(s["y"])("create-keep-component"),B=Object(s["y"])("profileKeepsComponent");return Object(s["r"])(),Object(s["e"])("div",a,[Object(s["h"])("div",o,[Object(s["h"])("div",r,[Object(s["h"])("img",{class:"rounded img-fluid",src:l.activeProfile.picture,alt:""},null,8,["src"])]),Object(s["h"])("div",i,[Object(s["h"])("div",n,[Object(s["h"])("div",b,Object(s["B"])(l.activeProfile.name),1)]),Object(s["h"])("div",d,[Object(s["h"])("div",p," Vaults: "+Object(s["B"])(l.profileVaults.length),1)]),Object(s["h"])("div",j,[Object(s["h"])("div",O," Keeps: "+Object(s["B"])(l.profileKeeps.length),1)])])]),Object(s["h"])("div",f,[Object(s["h"])("div",u,[v,Object(s["h"])(C)])]),Object(s["h"])("div",h,[Object(s["h"])("div",m,[(Object(s["r"])(!0),Object(s["e"])(s["a"],null,Object(s["x"])(l.profileVaults,e=>(Object(s["r"])(),Object(s["e"])(g,{key:e.id,"vault-prop":e},null,8,["vault-prop"]))),128))])]),Object(s["h"])("div",w,[Object(s["h"])("div",K,[P,Object(s["h"])(I)])]),Object(s["h"])("div",V,[Object(s["h"])("div",k,[(Object(s["r"])(!0),Object(s["e"])(s["a"],null,Object(s["x"])(l.profileKeeps,e=>(Object(s["r"])(),Object(s["e"])(B,{key:e.id,"keep-prop":e},null,8,["keep-prop"]))),128))])])])}));var y=c("83fc"),C=c("2b15"),g=c("792f"),I=c("3988"),B=c("0de1"),J=c("6c3f"),_=c("6c02"),q={name:"Profile",setup(){const e=Object(_["c"])();return Object(s["p"])(()=>{J["a"].getProfileById(e.params.profileId),J["a"].getProfileKeeps(e.params.profileId),J["a"].getProfileVaults(e.params.profileId)}),{activeProfile:Object(s["c"])(()=>y["a"].activeProfile),profileKeeps:Object(s["c"])(()=>y["a"].profileKeeps),profileVaults:Object(s["c"])(()=>y["a"].profileVaults)}},components:{CreateKeepComponent:C["default"],CreateVaultComponent:g["default"],ProfileKeepsComponent:I["default"],ProfileVaultsComponent:B["default"]}};c("156e");q.render=x,q.__scopeId="data-v-39695338";t["default"]=q},"57d0":function(e,t,c){}}]);