<template>
  <div id="app">
    <el-form :model="form" ref="form" label-width="80px">
      <el-row>
        <el-col :span="8">
          <el-form-item label>
            <el-input v-model="form.msg" placeholder="请输入消息"></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="4">
          <el-form-item>
            <el-button type="primary" @click="onSubmit">发送</el-button>
          </el-form-item>
        </el-col>
      </el-row>
    </el-form>
    <div>{{messages}}</div>
    <router-view></router-view>
  </div>
</template>

<script>
import HelloWorld from "./components/HelloWorld.vue";
import Value from "./components/Value.vue";
import $ from 'jquery';
import * as signalR from 'signalr';
window.jquery = $;

export default {
  name: "App",
  components: {
    HelloWorld,
    Value,
  },
  data() {
    return {
      form: {
        msg: "",
      },
      messages: "",
    };
  },
  methods: {
    onSubmit() {},
  },
  created() {
    var connection = signalR.hubConnection('localhost:9000');
    console.log(connection);
    // var connection = new signalR.HubConnectionBuilder()
    //   .withUrl("http://localhost:9000/signalr/hubs")
    //   .withAutomaticReconnect()
    //   .build();
    // connection.start().then((a) => {
    //   if (connection.connectionId) {
    //     connection
    //       .invoke("Send",'好难受啊')
    //       .catch((err) => console.log(err.toString()));
    //   }
    // });
    // connection.on("Hello", (userid, msg) => {
    //   console.log(userid + ":" + msg);
    // });
  },
  mounted() {},
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
