#!/bin/bash

# 네트워크 인터페이스 이름 설정 (예: eth0)
INTERFACE="eth0"

# 대역폭을 1mbps로 제한
tc qdisc add dev $INTERFACE root tbf rate 1mbit burst 32kbit latency 400ms
# apt-get update && apt-get install -y iproute2
# tc qdisc add dev eth0 root tbf rate 1mbit burst 32kbit latency 400ms