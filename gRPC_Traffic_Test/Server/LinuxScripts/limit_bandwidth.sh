#!/bin/bash

# ��Ʈ��ũ �������̽� �̸� ���� (��: eth0)
INTERFACE="eth0"

# �뿪���� 1mbps�� ����
tc qdisc add dev $INTERFACE root tbf rate 1mbit burst 32kbit latency 400ms
# apt-get update && apt-get install -y iproute2
# tc qdisc add dev eth0 root tbf rate 1mbit burst 32kbit latency 400ms