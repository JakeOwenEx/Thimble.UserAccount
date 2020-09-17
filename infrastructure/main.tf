terraform {
  backend "s3" {
    region  = "eu-west-1"
    bucket  = "thimble-terraform-state"
    key     = "useraccount/terraform.tfstate"        
  }
}  

provider "aws" {
  region = "eu-west-1"
}

data "aws_caller_identity" "current" {}

module "vpc" {
  source = "./vpc"
  service_name="useraccount"
}


