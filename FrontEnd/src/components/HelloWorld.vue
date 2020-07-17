<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <el-button type="primary" @click="gotoValue">{{buttonValue}}</el-button>
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
      buttonValue:"前往Value模块"
    }
  },
  methods:{
    gotoValue(){
      this.$router.push("value")
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
