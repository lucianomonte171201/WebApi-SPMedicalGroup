import {
  createAppContainer,
  createStackNavigator,
  createSwitchNavigator
} from "react-navigation";
import Login from "./pages/Login";
import Listar from "./pages/ListarConsultas";

const AuthStack = createStackNavigator({ Login });

const MainNavigator = createStackNavigator({ Listar });

export default createAppContainer(
  createSwitchNavigator(
      {
          MainNavigator,
          AuthStack
      },
      {
          initialRouteName: "MainNavigator"
      }
  )
);