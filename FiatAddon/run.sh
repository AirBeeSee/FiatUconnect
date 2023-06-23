#!/usr/bin/with-contenv bashio

export FiatUconnect_MqttUser=$(bashio::services "mqtt" "username")
export FiatUconnect_MqttPw=$(bashio::services "mqtt" "password")
export FiatUconnect_MqttServer=$(bashio::services "mqtt" "host")
export FiatUconnect_MqttPort=$(bashio::services "mqtt" "port")
  
export FiatUconnect_StartDelaySeconds=$(bashio::config 'StartDelaySeconds')
export FiatUconnect_SupervisorToken=$SUPERVISOR_TOKEN
  
export FiatUconnect_FiatUser=$(bashio::config 'FiatUser')
export FiatUconnect_FiatPw=$(bashio::config 'FiatPw')
export FiatUconnect_FiatPin=$(bashio::config 'FiatPin')
export FiatUconnect_Debug=$(bashio::config 'Debug')
export FiatUconnect_RefreshInterval=$(bashio::config 'RefreshInterval')
export FiatUconnect_AutoDeepRefresh=$(bashio::config 'AutoDeepRefresh')
export FiatUconnect_AutoDeepInterval=$(bashio::config 'AutoDeepInterval')
export FiatUconnect_StartDelaySeconds=$(bashio::config 'StartDelaySeconds')

cd /build/
./FiatUconnect
