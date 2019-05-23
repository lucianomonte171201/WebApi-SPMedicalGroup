import React, { Component } from 'react';
import { Text, TextInput, StyleSheet, ImageBackground, View, Image, TouchableOpacity, AsyncStorage } from 'react-native';
import jwt from "jwt-decode";
import api from "../services/api";


class Login extends Component {
  static navigationOptions = {
    header: null
  };

  constructor(props) {
    super(props);
    this.state = { email: "", senha: "" };
  }

  realizarLogin = async () => {
    const resposta = await api.post("/login", {
        email: this.state.email,
        senha: this.state.senha
    });

    const token = resposta.data.token;
    await AsyncStorage.setItem("userToken", token);
    this.props.navigation.navigate("MainNavigator");
}


  render() {
    return (
      <ImageBackground source={require("../assets/img/image1.jpg")}
        style={StyleSheet.absoluteFillObject}>
        <View style={styles.overlay} />

        <View style={styles.main}>

          <View style={styles.formaLogo}>

            <Image
              source={require("../assets/img/logo.png")}
              style={styles.tabNavigatorIconHome}
            />

          </View>

          {/* <Text style={styles.loginTitle}> Login </Text> */}

          <View style={styles.inputs}>

            <TextInput

              style={styles.inputLogin}
              placeholder="Insira seu e-mail"
              placeholderTextColor="#FFFFFF"
              underlineColorAndroid="#FFFFFF"
              onChangeText={email => this.setState({ email })}

            />

            <TextInput

              style={styles.inputLogin}
              placeholder="Insira sua senha"
              placeholderTextColor="#FFFFFF"
              underlineColorAndroid="#FFFFFF"
              secureTextEntry={true}
              onChangeText={senha => this.setState({ senha })}

            />

          </View>

          <TouchableOpacity style={styles.btnLogin} onPress={this.realizarLogin}>
            <Text style={styles.btnLoginText}>LOGIN</Text>
          </TouchableOpacity>

        </View>

      </ImageBackground>
    );
  }
}

const styles = StyleSheet.create({
  overlay: {
    ...StyleSheet.absoluteFillObject,
    backgroundColor: "rgba(115, 208, 248, 0.79)"
  },
  main: {
    width: "100%",
    height: "100%",
    alignItems: "center",
    marginTop: 90
  },
  formaLogo: {
    height: 110,
    width: 110,
    backgroundColor: "#FFFFFF",
    justifyContent: "center",
    alignItems: "center",
    borderRadius: 100,
    borderWidth: 2,
    borderColor: "#73F8CD"
  },
  loginTitle: {
    fontSize: 22,
    letterSpacing: 1,
    color: "#FFFFFF",
    textShadowColor: 'rgba(0, 0, 0, 0.85)',
    textShadowOffset: { width: -0.5, height: 0.5 },
    textShadowRadius: 15
  },
  tabNavigatorIconHome: {
    height: 70.8,
    width: 66
  },
  inputs: {
    marginTop: 40
  },
  inputLogin: {
    width: 240,
    marginTop: 20,
    fontSize: 14
  },
  btnLogin: {
    height: 38,
    shadowColor: "rgba(0,0,0, 0.4)",
    shadowOffset: { height: 1, width: 1 },
    shadowOpacity: 1,
    shadowRadius: 1,
    elevation: 3,
    width: 150,
    borderRadius: 50,
    borderWidth: 1,
    borderColor: "#FFFFFF",
    backgroundColor: "#FFFFFF",
    justifyContent: "center",
    alignItems: "center",
    marginTop: 50
  },
  btnLoginText: {
    fontSize: 12,
    fontFamily: "OpenSans-Light",
    letterSpacing: 2
  }

});

export default Login;