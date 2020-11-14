<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <el-button type="primary" @click="gotoPage('value')">{{buttonValue}}</el-button>
    <el-button type="primary" @click="gotoPage('socket')">{{buttonSocket}}</el-button>
    <!-- <router-link to="/value">{{buttonValue}}</router-link>
    <router-view></router-view> -->
  </div>
</template>

<script>
export default {
  name: 'HelloWorld',
  props: {
    msg: String
  },
  data(){
    return {
      buttonValue:"前往Value模块",
      buttonSocket:"测试Socket模块",
    }
  },
  mounted(){
    // this.$axios
    //     .get("http://localhost:9000/Connections/HelloConnection")
    //     .then(res => {
    //       console.log(res);
    //     })
    //     .catch(error => {
    //       console.log(error);
    //     });
  },
  methods:{
    gotoPage(name){
      this.$router.push(name)
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
